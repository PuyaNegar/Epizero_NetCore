using Common.Enums;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebViewModels.OnlineExamsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class StudentOnlineExamQuestionsComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<OnlineExamQuestionsModel> onlineExamQuestionsRepository;
        private Repository<OnlineExamStudentAnswersModel> onlineExamStudentAnswersRepository;
        public StudentOnlineExamQuestionsComponent()
        {
            mainDBContext = new MainDBContext();
            onlineExamQuestionsRepository = new Repository<OnlineExamQuestionsModel>(mainDBContext);
            onlineExamStudentAnswersRepository = new Repository<OnlineExamStudentAnswersModel>(mainDBContext);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public List<StudentOnlineExamQuestionsViewModel> Read(int onlineExamId, int studentUserId, bool IsOnlyReadQuestions = false, bool IsShowCorrectAnswer = false)
        {
            if (IsOnlyReadQuestions == false)
            {
                using (var addStudentToIndependentOnlineExam = new AddStudentToIndependentOnlineExam())
                {
                    addStudentToIndependentOnlineExam.Operation(onlineExamId, studentUserId);
                    EnterToExam(onlineExamId, studentUserId);
                }
            }
            var query = from onlineExamQuestion in onlineExamQuestionsRepository.Where(c => c.OnlineExamId == onlineExamId, c => c.OnlineExamMultipleChoiceQuestion, c => c.OnlineExamDescriptiveQuestion, c => c.QuestionType, c => c.Lesson)
                        join onlineExamStudentAnswer in onlineExamStudentAnswersRepository.Where(c => c.OnlineExamStudent.StudentUserId == studentUserId, c => c.DescrptiveQuestionAnswer, c => c.MultipleChoiceQuestionAnswer) on onlineExamQuestion.Id equals onlineExamStudentAnswer.OnlineExamQuestionId into ps
                        from temp in ps.DefaultIfEmpty()
                        select new StudentOnlineExamQuestionsViewModel()
                        {
                            Id = onlineExamQuestion.Id,
                            IsTextQuestionContext = onlineExamQuestion.IsTextQuestionContext,
                            OnlineExamId = onlineExamQuestion.OnlineExamId,
                            QuestionContext = onlineExamQuestion.QuestionContext,
                            QuestionTypeId = onlineExamQuestion.QuestionTypeId,
                            QuestionTypeName = onlineExamQuestion.QuestionType.Name,
                            LessonId = onlineExamQuestion.LessonId,
                            LessonName = onlineExamQuestion.Lesson.Name,
                            MultipleChoiceQuestionOptions = onlineExamQuestion.QuestionTypeId == (int)QuestionType.MultipleChoiceQuestions ? new StudentMultipleChoiceQuestionOptionsViewModel()
                            {
                                Id = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.Id,
                                Option1 = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.Option1,
                                Option2 = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.Option2,
                                Option3 = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.Option3,
                                Option4 = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.Option4,
                                IsTextOption1 = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.IsTextOption1,
                                IsTextOption2 = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.IsTextOption2,
                                IsTextOption3 = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.IsTextOption3,
                                IsTextOption4 = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.IsTextOption4,
                                CorrentOption = IsShowCorrectAnswer ? onlineExamQuestion.OnlineExamMultipleChoiceQuestion.CorrectOption : 0,
                            } : null,

                            DescriptiveAnswers = temp == null ? null : (temp.DescrptiveQuestionAnswer == null ? null : new StudentDescriptiveAnswersViewModel()
                            {
                                OnlineExamId = onlineExamQuestion.OnlineExamId,
                                OnlineExamQuestionId = onlineExamQuestion.Id,
                                AnswerContext = temp.DescrptiveQuestionAnswer.AnswerContext
                            }),
                            MultipeChoiceAnswer = temp == null ? null : (temp.MultipleChoiceQuestionAnswer == null ? null : new StudentMultipeChoiceAnswerViewModel()
                            {
                                OnlineExamId = onlineExamQuestion.OnlineExamId,
                                OnlineExamQuestionId = onlineExamQuestion.Id,
                                SelectedOption = temp.MultipleChoiceQuestionAnswer.SelectedOption,
                            }),
                        };
            return query.ToList();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        void EnterToExam(int onlineExamId, int studentUserId)
        {
            using (var studentOnlineExamValidationsComponent = new StudentOnlineExamValidationsComponent())
            {
                double RemainingTime = 0;
                studentOnlineExamValidationsComponent.Operation(onlineExamId, studentUserId, ref RemainingTime, true);
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            // questionsRepository?.Dispose();
        }
        #endregion
    }
}
