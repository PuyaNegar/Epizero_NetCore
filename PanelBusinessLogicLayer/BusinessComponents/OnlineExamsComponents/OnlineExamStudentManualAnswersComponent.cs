using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using PanelViewModels.OnlineExamsViewModels;
using PanelViewModels.OnlineExamViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class OnlineExamStudentManualAnswersComponent : IDisposable
    {
        private MainDBContext mainDbContext;
        Repository<MultipleChoiceQuestionAnswersModel> multipleChoiceQuestionAnswersRepository;
        Repository<OnlineExamStudentAnswersModel> repository;
        public OnlineExamStudentManualAnswersComponent()
        {
            mainDbContext = new MainDBContext();
            multipleChoiceQuestionAnswersRepository = new Repository<MultipleChoiceQuestionAnswersModel>(mainDbContext);
            repository = new Repository<OnlineExamStudentAnswersModel>(mainDbContext);
        }
        //===================================================
        public List<OnlineExamQuestionGroupsViewModel> Read(int onlineExamStudentId)
        {
            using (var onlineExamQuestionsComponent = new OnlineExamQuestionsComponent())
            {
                var result = GetOnlineExamStudent(onlineExamStudentId, null, false);
                return onlineExamQuestionsComponent.Read( result.OnlineExamId, false);
            }
        }
        //===================================================
        public void Add(int onlineExamStudentId, List<OnlineExamStudentManualAnswerSelectedOptionsViewModel> manualAnswers, int currentUserId)
        {
            using (var transaction = mainDbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {

                    var onlineExamStudent = GetOnlineExamStudent(onlineExamStudentId, mainDbContext, true);
                    CheckOnlineExamQuestion(onlineExamStudent, manualAnswers);
                    var OnlineExamStudentAnswers = new List<OnlineExamStudentAnswersModel>(); 
                    DeleteOldAnswers(onlineExamStudentId); 
                    foreach (var manualAnswer in manualAnswers.Where(c => 1 <= c.SelectedOption && c.SelectedOption <= 4))
                    {
                        var model = new OnlineExamStudentAnswersModel()
                        {
                            OnlineExamQuestionId = manualAnswer.QuestionId,
                            OnlineExamStudentId = onlineExamStudentId,
                            RegDateTime = DateTime.UtcNow,
                            ModUserId = currentUserId,
                            MultipleChoiceQuestionAnswer = new MultipleChoiceQuestionAnswersModel()
                            {
                                RegDateTime = DateTime.UtcNow,
                                ModUserId = currentUserId,
                                SelectedOption = manualAnswer.SelectedOption,
                            }
                        };
                        OnlineExamStudentAnswers.Add(model);
                    }
                    repository.AddRange(OnlineExamStudentAnswers);
                    repository.SaveChanges();
                    transaction.Commit();
                    studentOnlineExamFinalize(onlineExamStudentId);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new CustomException(ex.Message);
                }
            }

        }

        void DeleteOldAnswers(int onlineExamStudentId)
        {
            multipleChoiceQuestionAnswersRepository.Delete(c => c.OnlineExamStudentAnswer.OnlineExamStudentId == onlineExamStudentId);
            multipleChoiceQuestionAnswersRepository.SaveChanges();

            repository.Delete(c => c.OnlineExamStudentId == onlineExamStudentId);
            repository.SaveChanges();
        }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        void CheckOnlineExamQuestion(OnlineExamStudentsModel onlineExamStudent, List<OnlineExamStudentManualAnswerSelectedOptionsViewModel> manualAnswers)
        {
            if (onlineExamStudent.IsFinalized)
                throw new CustomException("آزمون نهایی شده است و امکان افزودن پاسخ برگ ممکن نیست");
            var questionIds = manualAnswers.Select(c => c.QuestionId).ToList();
            using (var onlineExamQuestionRepository = new Repository<OnlineExamQuestionsModel>())
            {
                var onlineExamQuestions = onlineExamQuestionRepository.Where(c => c.OnlineExamId == onlineExamStudent.OnlineExamId).Select(c => c.Id).ToList();
                var ccc = questionIds.Except(onlineExamQuestions);
                if (questionIds.Except(onlineExamQuestions).Any())
                    throw new CustomException("برخی از سوالات این آزمون معتبر نمی باشد");
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        OnlineExamStudentsModel GetOnlineExamStudent(int onlineExamStudentId, MainDBContext mainDBContext, bool IsUpdateEnterDateTime)
        {
            using (var onlineExamStudentsRepository = mainDBContext == null ? new Repository<OnlineExamStudentsModel>() : new Repository<OnlineExamStudentsModel>(mainDBContext))
            {
                var result = onlineExamStudentsRepository.SingleOrDefault(c => c.Id == onlineExamStudentId, c => c.OnlineExam);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);

                if (result.EnterDateTime != null)
                    throw new CustomException("دانش آموز قبلا به آزمون ورود کرده است و امکان پاسخ دستی به آزمون توسط دبیر ممکن نیست");

                //if (result.OnlineExam.StartDateTime.AddMinutes(result.OnlineExam.Duration).AddMinutes(result.OnlineExam.AllowedTimeToEnter == null ? 0 : result.OnlineExam.AllowedTimeToEnter.Value) > DateTime.UtcNow)
                //    throw new CustomException("زمان برگذاری آزمون هنوز به پایان نرسیده است بعد از اتمام زمان آزمون امکان ثبت پاسخ برگ وجود دارد");

                if(result.OnlineExam.StartDateTime > DateTime.UtcNow)
                    throw new CustomException("زمان آزمون فرا نرسیده است");

                if (IsUpdateEnterDateTime)
                {
                    result.EnterDateTime = result.OnlineExam.StartDateTime;
                    onlineExamStudentsRepository.Update(result);
                    onlineExamStudentsRepository.SaveChanges();
                }
                return result;
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        void studentOnlineExamFinalize(int onlineExamStudentId)
        {
            using (var studentOnlineExamFinalizeComponent = new StudentOnlineExamFinalizeComponent())
            {
                studentOnlineExamFinalizeComponent.Operation(onlineExamStudentId);
            };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            mainDbContext?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
