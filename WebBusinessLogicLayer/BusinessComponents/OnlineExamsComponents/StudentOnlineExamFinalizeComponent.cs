using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class StudentOnlineExamFinalizeComponent : IDisposable
    {
        private MainDBContext mainDbContext;
        private Repository<OnlineExamStudentsModel> studentOnlineExamsRepository;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public StudentOnlineExamFinalizeComponent()
        {
            mainDbContext = new MainDBContext();
            studentOnlineExamsRepository = new Repository<OnlineExamStudentsModel>(mainDbContext);
        }

        public static bool IsFinalized(int onlineExamId, int? studentUserId)
        {
            using (var studentOnlineExamsRepository = new Repository<OnlineExamStudentsModel>())
            {
                if (studentUserId == null)
                    return false;
                var result = studentOnlineExamsRepository.SingleOrDefault(c => c.StudentUserId == studentUserId && c.OnlineExamId == onlineExamId);
                if (result == null)
                    return false;
                if (result.IsFinalized)
                    return true;
                else
                    return false;
            }
        }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Operation(int onlineExamId, int studentUserId, ref int OnlineExamStudentId)
        {
            using (var transaction = mainDbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var result = studentOnlineExamsRepository.SingleOrDefault(c => c.OnlineExamId == onlineExamId && c.StudentUserId == studentUserId && c.EnterDateTime != null, c => c.OnlineExam);
                    if (result == null)
                        throw new CustomException(SystemCommonMessage.DataWasNotFound);
                    if (result.IsFinalized == false)
                    {
                        result.IsFinalized = true;
                        result.FinalizedDateTime = DateTime.UtcNow;
                        studentOnlineExamsRepository.Update(result);
                        studentOnlineExamsRepository.SaveChanges();
                        if (result.OnlineExam.QuestionTypeId == (int)QuestionType.MultipleChoiceQuestions)
                        {
                            var model = CorrectQuestions(onlineExamId, studentUserId, result.Id, result.OnlineExam.MaxGrade, result.OnlineExam.HasNegativePoint);
                            AddStudentOnlineExamResults(model);
                        }
                        transaction.Commit();

                    }
                    OnlineExamStudentId = result.Id;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new CustomException(ex.Message);
                }
            }
        }
        //=======================================================================
        void AddStudentOnlineExamResults(List<StudentOnlineExamResultsModel> models)
        {
            using (var repository = new Repository<StudentOnlineExamResultsModel>(mainDbContext))
            {
                repository.AddRange(models);
                repository.SaveChanges();
            }
        }
        //=======================================================================
        List<StudentOnlineExamResultsModel> CorrectQuestions(int onlineExamId, int studentUserId, int onlineExamStudentId, int MaxGrade, bool HasNegativePoint)
        {
            using (var studentOnlineExamQuestionsComponent = new StudentOnlineExamQuestionsComponent())
            {
                var questionAnswers = studentOnlineExamQuestionsComponent.Read(onlineExamId, studentUserId, IsOnlyReadQuestions: true, IsShowCorrectAnswer: true);
                if (questionAnswers.Where(c => c.QuestionTypeId != (int)QuestionType.MultipleChoiceQuestions).Any())
                    throw new CustomException("برخی از سوالات این آزمون تستی نمی باشد و امکان اصلاح آنلاین ممکن نیست");

                //============================================
                var questionAnswerGroups = questionAnswers.GroupBy(c => new { c.LessonId, c.LessonName }).Select(c => new
                {
                    LessonId = c.Key.LessonId,
                    LessonName = c.Key.LessonName,
                    QuestionAnswers = c.ToList(),
                }).ToList();

                //============================================
                var models = new List<StudentOnlineExamResultsModel>();
                foreach (var questionAnswerGroup in questionAnswerGroups)
                {
                    var model = new StudentOnlineExamResultsModel()
                    {
                        LessonId = questionAnswerGroup.LessonId,
                        OnlineExamStudentId = onlineExamStudentId,
                        CorrectAnswered = 0,
                        IncorrectAnswered = 0,
                        Unanswered = 0,
                    };
                    foreach (var questionAnswer in questionAnswerGroup.QuestionAnswers)
                    {
                        if (questionAnswer.MultipeChoiceAnswer == null)
                            model.Unanswered += 1;
                        else
                        {
                            if (questionAnswer.MultipleChoiceQuestionOptions.CorrentOption == questionAnswer.MultipeChoiceAnswer.SelectedOption)
                                model.CorrectAnswered += 1;
                            else
                                model.IncorrectAnswered += 1;
                        }
                    }
                    models.Add(CalculateRawScore(model, MaxGrade, HasNegativePoint));
                }
                return models;
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public StudentOnlineExamResultsModel CalculateRawScore(StudentOnlineExamResultsModel result, int MaxGrade, bool HasNegativePoint)
        {
            int QuestionCount = result.CorrectAnswered + result.IncorrectAnswered + result.Unanswered;
            if (HasNegativePoint)
            {
                var b = Convert.ToDecimal((3 * result.CorrectAnswered) - result.IncorrectAnswered) / (3 * QuestionCount);
                var a = (float)b * 100;
                result.RawScore = (float)Math.Round(a * MaxGrade / 100 * 100f) / 100f;
            }
            else
            {
                result.RawScore = (float)Math.Round(((float)MaxGrade / QuestionCount * result.CorrectAnswered * 100f)) / 100f;
            }
            return result;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            mainDbContext?.Dispose();
            studentOnlineExamsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
