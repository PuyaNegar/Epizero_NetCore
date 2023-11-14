using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using DataModels.OnlineExamModels;
using PanelViewModels.OnlineExamsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class OnlineExamStudentAnswersComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<OnlineExamQuestionsModel> onlineExamQuestionsRepository;
        private Repository<OnlineExamStudentAnswersModel> onlineExamStudentAnswersRepository;
        //=========================================================================================
        public OnlineExamStudentAnswersComponent()
        {
            mainDBContext = new MainDBContext();
            onlineExamQuestionsRepository = new Repository<OnlineExamQuestionsModel>(mainDBContext);
            onlineExamStudentAnswersRepository = new Repository<OnlineExamStudentAnswersModel>(mainDBContext);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamStudentAnswersViewModel Read(int onlineExamStudentId)
        {
            var onlineExamStudent = GetOnlineExamStudents(onlineExamStudentId);
            var query = from onlineExamQuestion in onlineExamQuestionsRepository.Where(c => c.OnlineExamId == onlineExamStudent.OnlineExamId, c => c.OnlineExamMultipleChoiceQuestion, c => c.OnlineExamDescriptiveQuestion, c => c.QuestionType, c => c.Lesson)
                        join onlineExamStudentAnswer in onlineExamStudentAnswersRepository.Where(c => c.OnlineExamStudent.StudentUserId == onlineExamStudent.StudentUserId, c => c.DescrptiveQuestionAnswer, c => c.MultipleChoiceQuestionAnswer) on onlineExamQuestion.Id equals onlineExamStudentAnswer.OnlineExamQuestionId into ps
                        from temp in ps.DefaultIfEmpty()
                        select new StudentOnlineExamQuestionsViewModel()
                        {
                            Id = onlineExamQuestion.Id,
                            OnlineExamId = onlineExamQuestion.OnlineExamId,
                            QuestionContext = onlineExamQuestion.QuestionContext,
                            QuestionTypeId = onlineExamQuestion.QuestionTypeId,
                            QuestionTypeName = onlineExamQuestion.QuestionType.Name,
                            LessonId = onlineExamQuestion.LessonId,
                            LessonName = onlineExamQuestion.Lesson.Name,
                            MultipleChoiceQuestionOptions = onlineExamQuestion.QuestionTypeId == (int)QuestionType.MultipleChoiceQuestions ? new StudentMultipleChoiceQuestionOptionsViewModel()
                            {
                                Id = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.Id,
                                CorrentOption = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.CorrectOption,
                                Option1 = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.Option1,
                                Option2 = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.Option2,
                                Option3 = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.Option3,
                                Option4 = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.Option4
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

            var model = new OnlineExamStudentAnswersViewModel()
            {
                StudentFullName = onlineExamStudent.StudentUser.FirstName + " " + onlineExamStudent.StudentUser.LastName,
                ExamName = onlineExamStudent.OnlineExam.Name,
                StudentOnlineExamQuestions = query.ToList(),
                OnlineExamStudentAnswerFiles = GetOnlineExamStudentAnswerFiles(onlineExamStudent.Id)
            };
            return model;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        OnlineExamStudentsModel GetOnlineExamStudents(int onlineExamStudentId)
        {
            using (var repository = new Repository<OnlineExamStudentsModel>())
            {
                var result = repository.Where(c => c.Id == onlineExamStudentId, c => c.OnlineExam, c => c.StudentUser).Select(c => new OnlineExamStudentsModel()
                {
                    Id = c.Id,
                    StudentUserId = c.StudentUserId,
                    OnlineExamId = c.OnlineExamId,
                    OnlineExam = new OnlineExamsModel() { Name = c.OnlineExam.Name },
                    StudentUser = new UsersModel()
                    {
                        FirstName = c.StudentUser.FirstName,
                        LastName = c.StudentUser.LastName,
                    }
                }).SingleOrDefault();
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result;
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        List<OnlineExamStudentAnswerFilesViewModel> GetOnlineExamStudentAnswerFiles(int onlineExamStudentId)
        {
            using (var repository = new Repository<OnlineExamStudentAnswerFilesModel>())
            {
                var cdnUrl = AppConfigProvider.CdnUrl();
                var result = repository.Where(c => c.OnlineExamStudentId == onlineExamStudentId).ToList().Select(c => new OnlineExamStudentAnswerFilesViewModel()
                {
                    Id = c.Id,
                    FilePath = cdnUrl + c.FilePath,
                    FileFormat = c.FilePath.Split('.')[0],
                }).ToList();
                return result;
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            mainDBContext?.Dispose();
            onlineExamQuestionsRepository?.Dispose();
            onlineExamStudentAnswersRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    }
}
