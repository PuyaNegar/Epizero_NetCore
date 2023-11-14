using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Linq;
using Common.Extentions;
using System.Collections.Generic;
using Common.Functions;
using Common.Objects;
using WebViewModels.TrainingsViewModels;
using Common.Enums;
using WebBusinessLogicLayer.UtilityComponent;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
    public class CourseStudentQuestionsComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<CourseStudentQuestionAnswersModel> courseStudentQuestionAnswersRepository;
        private Repository<CourseStudentQuestionsModel> courseStudentQuestionsRepository;
        //===========================================
        public CourseStudentQuestionsComponent()
        {
            mainDBContext = new MainDBContext();
            courseStudentQuestionAnswersRepository = new Repository<CourseStudentQuestionAnswersModel>(mainDBContext);
            courseStudentQuestionsRepository = new Repository<CourseStudentQuestionsModel>(mainDBContext);
        }
        //===========================================
        public List<CourseStudentQuestionsViewModel> Read(int courseId, int? studentUserId, bool isShowNoVerifiedQuestion)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var courseStudentQuestionsQuery = courseStudentQuestionsRepository.Where(c => c.CourseId == courseId, c => c.StudentUser);
            if (!isShowNoVerifiedQuestion)
                courseStudentQuestionsQuery = courseStudentQuestionsQuery.Where(c => c.IsVerified.Value);
            if (studentUserId != null)
                courseStudentQuestionsQuery = courseStudentQuestionsQuery.Where(c => c.StudentUserId == studentUserId);
            var query = from courseStudentQuestions in courseStudentQuestionsQuery
                        join courseStudentQuestionAnswers in courseStudentQuestionAnswersRepository.Where(c => c.IsVerified.Value, c => c.AnsweredUser) on courseStudentQuestions.Id equals courseStudentQuestionAnswers.StudentQuestionId into t
                        from temp in t.DefaultIfEmpty()
                        select new
                        {
                            QuestionPicPath = courseStudentQuestions.QuestionPicPath,
                            QuestionFilePath = courseStudentQuestions.QuestionFilePath,
                            AudioPath = courseStudentQuestions.AudioPath,
                            CourseStudentQuestionId = courseStudentQuestions.Id,
                            IsVerfiedQuestion = courseStudentQuestions.IsVerified,
                            QuestionContext = courseStudentQuestions.QuestionContext,
                            QuestionRegDateTime = courseStudentQuestions.RegDateTime,
                            StudentUserFullName = courseStudentQuestions.StudentUser.FirstName + " " + courseStudentQuestions.StudentUser.LastName,
                            HasAnswer = temp == null ? false : true,
                            AnswerdUserFullName = temp == null ? string.Empty : temp.AnsweredUser.FirstName + " " + temp.AnsweredUser.LastName,
                            AnswerdUserPicPath = temp == null ? string.Empty : temp.AnsweredUser.PersonalPicPath,
                            StudentUserPicPath = courseStudentQuestions.StudentUser.PersonalPicPath,
                            AnswerContext = temp == null ? string.Empty : temp.AnswerContext,
                            AnswerFilePath = temp == null ? string.Empty : temp.AnswerFilePath,
                            AnswerPicPath = temp == null ? string.Empty : temp.AnswerPicPath,
                            AnswerAudioPath = temp == null ? string.Empty : temp.AudioPath,
                            CourseStudentQuestionAnswerId = temp == null ? (int?)null : temp.Id,
                            QuestionAnswerRegDateTime = temp == null ? null : temp.VerifiedDateTime,
                            IsBestAnswer = temp == null ? (bool?)null : temp.IsBestAnswer,

                        };
            var result = query.ToList().OrderBy(c => c.QuestionRegDateTime).GroupBy(c => new { c.AudioPath, c.QuestionFilePath, c.QuestionPicPath, c.CourseStudentQuestionId, c.QuestionContext, c.StudentUserFullName,c.StudentUserPicPath, c.HasAnswer, c.QuestionRegDateTime, c.IsVerfiedQuestion }).Select(c => new CourseStudentQuestionsViewModel()
            {
                Id = c.Key.CourseStudentQuestionId,
                QuestionFilePath = string.IsNullOrEmpty(c.Key.QuestionFilePath) ? null : cdnUrl + c.Key.QuestionFilePath,
                QuestionPicPath = string.IsNullOrEmpty(c.Key.QuestionPicPath) ? null : cdnUrl + c.Key.QuestionPicPath,
                AudioPath = string.IsNullOrEmpty(c.Key.AudioPath) ? null : cdnUrl + c.Key.AudioPath,
                ConfirmStatusType = c.Key.IsVerfiedQuestion == null ? "در انتظار تایید" : c.Key.IsVerfiedQuestion.Value ? "تایید شده" : "رد شده",
                StudentUserFullName = c.Key.StudentUserFullName,
                StudentUserPicPath =string.IsNullOrEmpty(c.Key.StudentUserPicPath) ? null : cdnUrl + c.Key.StudentUserPicPath,
                QuestionContext = c.Key.QuestionContext,
                RegDateTime = c.Key.QuestionRegDateTime.ToLocalDateTimeLongFormatString(),
                NoBestAnswerCount = !c.Key.HasAnswer ? 0 : c.Where(d => d.IsBestAnswer != null && !d.IsBestAnswer.Value).Count(),
                BestAnswerCount = !c.Key.HasAnswer ? 0 : c.Where(d => d.IsBestAnswer != null && d.IsBestAnswer.Value).Count(),
                CourseStudentQuestionAnswers = !c.Key.HasAnswer ? new List<CourseStudentQuestionAnswersViewModel>() : c.OrderBy(d => d.IsBestAnswer).ThenBy(c => c.QuestionAnswerRegDateTime).Select(d => new CourseStudentQuestionAnswersViewModel()
                {
                    AnswerAudioPath = string.IsNullOrEmpty(d.AudioPath) ? null : cdnUrl + d.AnswerAudioPath,
                    AnswerFilePath = string.IsNullOrEmpty(d.AnswerFilePath) ? null : cdnUrl + d.AnswerFilePath,
                    AnswerPicPath = string.IsNullOrEmpty(d.AnswerPicPath) ? null : cdnUrl + d.AnswerPicPath,
                    AnswerContext = d.AnswerContext,
                    AnsweredUserFullName = d.AnswerdUserFullName,
                    AnswerdUserPicPath =string.IsNullOrEmpty(d.AnswerdUserPicPath)? null: cdnUrl + d.AnswerdUserPicPath,
                    Id = d.CourseStudentQuestionAnswerId.Value,
                    RegDateTime = d.QuestionAnswerRegDateTime.Value.ToLocalDateTimeLongFormatString(),
                    IsBestAnswer = d.IsBestAnswer.Value,
                }).ToList()
            }).ToList();
            return result;
        }
        //=================================================================
        public void AddAnswer(CourseStudentQuestionAnswersModel model, int studentUserId)
        {
            var courseStudentQuestions = courseStudentQuestionsRepository.SingleOrDefault(c => c.Id == model.StudentQuestionId);
            if (courseStudentQuestions == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            var result = StudentCourseMeetingsComponent.Read(studentUserId).Select(c => c.CourseId).Distinct();
            if (!result.Any(c => c == courseStudentQuestions.CourseId))
                throw new CustomException(SystemCommonMessage.NotAllowedToPerformThisOperation);
            model.AnswerFilePath = FileComponentProvider.Save(Common.Enums.FileFolder.CourseStudentQuestions, model.AnswerFilePath);
            model.AnswerPicPath = FileComponentProvider.Save(Common.Enums.FileFolder.CourseStudentQuestions, model.AnswerPicPath);
            model.AudioPath = FileComponentProvider.Save(Common.Enums.FileFolder.AudioCourseStudentQuestions, model.AudioPath);
            courseStudentQuestionAnswersRepository.Add(model);
            courseStudentQuestionAnswersRepository.SaveChanges();
        }
        //=================================================================
        public void Add(CourseStudentQuestionsModel model, int studentUserId)
        {
            var result = StudentCourseMeetingsComponent.Read(studentUserId).Select(c => c.CourseId).Distinct();
            if (!result.Any(c => c == model.CourseId))
                throw new CustomException(SystemCommonMessage.NotAllowedToPerformThisOperation);

            model.QuestionFilePath = FileComponentProvider.Save(Common.Enums.FileFolder.CourseStudentQuestions, model.QuestionFilePath);
            model.QuestionPicPath = FileComponentProvider.Save(Common.Enums.FileFolder.CourseStudentQuestions, model.QuestionPicPath);
            model.AudioPath = FileComponentProvider.Save(Common.Enums.FileFolder.AudioCourseStudentQuestions, model.AudioPath);
            courseStudentQuestionsRepository.Add(model);
            courseStudentQuestionsRepository.SaveChanges();
        }
        //================================================================= Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseStudentQuestionAnswersRepository?.Dispose();
            courseStudentQuestionsRepository?.Dispose();
            mainDBContext?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
