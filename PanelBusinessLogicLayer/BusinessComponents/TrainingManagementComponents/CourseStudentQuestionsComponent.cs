using Common.Enums;
using DataAccessLayer.Repositories;
using DataAccessLayer.StoredProcedures;
using DataModels.TrainingManagementModels;
using PanelViewModels.TrainingManagementViewModels;
using Common.Extentions;
using System;
using System.Linq;
using Common.Functions;
using Common.Objects;
using PanelBusinessLogicLayer.UtilityComponents.SmsComponents;
using PanelBusinessLogicLayer.UtilityComponent;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
    public class CourseStudentQuestionsComponent : IDisposable
    {
        private Repository<CourseStudentQuestionsModel> courseStudentQuestionsRepository;
        //===============================================
        public CourseStudentQuestionsComponent()
        {
            courseStudentQuestionsRepository = new Repository<CourseStudentQuestionsModel>();
        }
        //===============================================
        public IQueryable<CourseStudentQuestionsModel> Read(ConfirmStatusType confirmStatusType, int? CourseId)
        {
            CourseStudentQuestionsUnVerifyAnswerCountProcedure.Execute();
            var query = courseStudentQuestionsRepository.SelectAllAsQuerable(c => c.Course, c => c.StudentUser);
            if (CourseId != null)
                query = query.Where(c => c.CourseId == CourseId);
            if (confirmStatusType == ConfirmStatusType.Padding)
                query = query.Where(c => c.UnVerifyAnswerCount > 0 || c.IsVerified == null);
            if (confirmStatusType == ConfirmStatusType.Confirmed)
                query = query.Where(c => c.UnVerifyAnswerCount == 0 && c.IsVerified.Value);
            if (confirmStatusType == ConfirmStatusType.Rejected)
                query = query.Where(c => c.UnVerifyAnswerCount == 0 && !c.IsVerified.Value);
            return query;
        }
        //===============================================
        public CourseStudentQuestionsModel Find(int Id)
        {
            var result = courseStudentQuestionsRepository.SingleOrDefault(c => c.Id == Id, c => c.StudentUser, c => c.Course);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //===============================================
        public void Confirm(StudentCourseQuestionConfirmViewModel viewModel, int currentUserId)
        {
            var result = courseStudentQuestionsRepository.SingleOrDefault(c => c.Id == viewModel.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.IsVerified = viewModel.IsVerified.Value.ToBoolean();
            result.VerifiedDateTime = DateTime.UtcNow;
            result.ModUserId = currentUserId;
            result.ModDateTime = DateTime.UtcNow;
            courseStudentQuestionsRepository.Update(result);
            courseStudentQuestionsRepository.SaveChanges();
            new StudentUserScoresComponent().Reward(result.StudentUserId, ScoringTariffs.Reviews , currentUserId);
        }
        //===============================================
        public StudentCourseQuestionsViewModel ReadAnswers(int studentQuestionId)
        {
            using (var courseStudentQuestionAnswersRepository = new Repository<CourseStudentQuestionAnswersModel>())
            {
                var cdnUrl = AppConfigProvider.CdnUrl();
                var result = courseStudentQuestionsRepository.SingleOrDefault(c => c.Id == studentQuestionId, c => c.StudentUser, c => c.Course);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                var courseStudentQuestionAnswers = courseStudentQuestionAnswersRepository.Where(c => c.StudentQuestionId == studentQuestionId, c => c.AnsweredUser);
                var model = new StudentCourseQuestionsViewModel()
                {
                    Id = result.Id,
                    QuestionContext = result.QuestionContext,
                    StudentUserFullName = result.StudentUser.FirstName + " " + result.StudentUser.LastName,
                    CourseName = result.Course.Name,
                    RegDateTime = result.RegDateTime.ToLocalDateTimeShortFormatString(),
                    StudentCourseQuestionAnswers = courseStudentQuestionAnswers.Select(c => new StudentCourseQuestionAnswersViewModel()
                    {
                        Id = c.Id,
                        AnswerAudioPath = string.IsNullOrEmpty(c.AudioPath) ? null : cdnUrl + c.AudioPath,
                        AnswerFilePath = string.IsNullOrEmpty(c.AnswerFilePath) ? null : cdnUrl + c.AnswerFilePath,
                        AnswerPicPath = string.IsNullOrEmpty(c.AnswerPicPath) ? null : cdnUrl + c.AnswerPicPath,
                        AnsweredUserFullName = c.AnsweredUser.FirstName + " " + c.AnsweredUser.LastName,
                        RegDateTime = c.RegDateTime.ToLocalDateTimeShortFormatString(),
                        AnswerContext = c.AnswerContext,
                        ConfirmStatusType = c.IsVerified == null ? "بررسی نشده" : c.IsVerified.Value ? "تایید شده" : "رد شده",
                        IsBestAnswer = c.IsBestAnswer,
                    }).ToList()
                };
                return model;
            }
        }
        //===============================================
        public void ConfirmAnswer(StudentCourseQuestionAnswerConfirmViewModel viewModel, int currentUserId)
        {
            using (var courseStudentQuestionAnswersRepository = new Repository<CourseStudentQuestionAnswersModel>())
            {
                var result = courseStudentQuestionAnswersRepository.SingleOrDefault(c => c.Id == viewModel.Id);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                result.IsVerified = viewModel.IsVerified.ToBoolean();
                result.VerifiedDateTime = DateTime.UtcNow;
                result.ModUserId = currentUserId;
                result.ModDateTime = DateTime.UtcNow;
                result.IsBestAnswer = !viewModel.IsVerified.ToBoolean() ? false : viewModel.IsBestAnswer.ToBoolean();
                courseStudentQuestionAnswersRepository.Update(result);
                courseStudentQuestionAnswersRepository.SaveChanges();
            }
        }
        //===============================================
        public void AddAdminAnswers(CourseStudentQuestionAnswersModel model)
        {
            using (var courseStudentQuestionAnswersRepository = new Repository<CourseStudentQuestionAnswersModel>())
            {
                model.AnswerFilePath = FileComponentProvider.Save(Common.Enums.FileFolder.CourseStudentQuestions, model.AnswerFilePath);
                model.AnswerPicPath = FileComponentProvider.Save(Common.Enums.FileFolder.CourseStudentQuestions, model.AnswerPicPath);
                model.AudioPath = FileComponentProvider.Save(Common.Enums.FileFolder.AudioCourseStudentQuestions, model.AudioPath);
                courseStudentQuestionAnswersRepository.Add(model);
                courseStudentQuestionAnswersRepository.SaveChanges();
                CourseQuestionAnswerSmsComponent.Operation(model.Id);
            }
        }
        //===============================================
        #region DisposeObject
        public void Dispose()
        {
            courseStudentQuestionsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
