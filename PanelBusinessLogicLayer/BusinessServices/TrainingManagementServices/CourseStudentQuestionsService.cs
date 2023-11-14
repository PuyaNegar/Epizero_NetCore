using Common.Enums;
using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Linq;
using Common.Extentions;
using DataModels.TrainingManagementModels;
using Common.Functions;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class CourseStudentQuestionsService : IDisposable
    {
        private CourseStudentQuestionsComponent courseStudentQuestionsComponent;
        //===============================================================================
        public CourseStudentQuestionsService()
        {
            courseStudentQuestionsComponent = new CourseStudentQuestionsComponent();
        }
        //===============================================================================
        public SysResult Read(ConfirmStatusType confirmStatusType, int? CourseId)
        {
            var result = courseStudentQuestionsComponent.Read(confirmStatusType, CourseId).Select(c => new StudentCourseQuestionsViewModel()
            {
                Id = c.Id,
                UnVerifiedAnswerCount = c.UnVerifyAnswerCount,
                QuestionContext = c.QuestionContext,
                CourseName = c.Course.Name,
                StudentUserFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                VerifiedDateTime = c.VerifiedDateTime == null ? "ثبت نشده" : c.VerifiedDateTime.Value.ToLocalDateTimeShortFormatString(),
                RegDateTime = c.RegDateTime.ToLocalDateTimeShortFormatString(),
                CourseStatusType = c.IsVerified == null ? "درحال بررسی" : (c.IsVerified.Value ? "تایید شده" : "رد شده"),
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult Confirm(StudentCourseQuestionConfirmViewModel viewModel, int currentUserId)
        {
            courseStudentQuestionsComponent.Confirm(viewModel, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //===============================================================================
        public SysResult<StudentCourseQuestionsViewModel> ReadAnswers(int studentQuestionId)
        {
            var result = courseStudentQuestionsComponent.ReadAnswers(studentQuestionId);
            return new SysResult<StudentCourseQuestionsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult AddAdminAnswers(StudentCourseQuestionAdminAnswersViewModel viewModel, int currentUserId)
        {
            var model = new CourseStudentQuestionAnswersModel()
            {
                AnswerContext = viewModel.AnswerContext,
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
                IsBestAnswer = viewModel.IsBestAnswer.ToBoolean(),
                AnswerPicPath = viewModel.AnswerPicPath,
                AnswerFilePath = viewModel.AnswerFilePath,
                AudioPath = viewModel.AudioPath,
                AnsweredUserId = currentUserId,
                IsVerified = true,
                VerifiedDateTime = DateTime.UtcNow,
                StudentQuestionId = viewModel.QuestionId,
            };
            courseStudentQuestionsComponent.AddAdminAnswers(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded, };
        }
        //============================================================================
        public SysResult<StudentCourseQuestionConfirmViewModel> Find(int id)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var result = courseStudentQuestionsComponent.Find(id);
            var viewModel = new StudentCourseQuestionConfirmViewModel()
            {
                Id = result.Id,
                StudentUserFullName = result.StudentUser.FirstName + " " + result.StudentUser.LastName,
                IsVerified = result.IsVerified == null ? (ActiveStatus?)null : result.IsVerified.Value.ToActiveStatus(),
                VerifiedDateTime = result.IsVerified == null ? "ثبت نشده" : result.VerifiedDateTime.Value.ToLocalDateTimeShortFormatString(),
                QuestionContext = result.QuestionContext,
                RegDateTime = result.RegDateTime.ToLocalDateTimeShortFormatString(),
                CourseName = result.Course.Name,
                QuestionFilePath = string.IsNullOrEmpty(result.QuestionFilePath) ? null : cdnUrl + result.QuestionFilePath,
                QuestionPicPath = string.IsNullOrEmpty(result.QuestionPicPath) ? null : cdnUrl + result.QuestionPicPath,
                AudioPath = string.IsNullOrEmpty(result.AudioPath) ? null : cdnUrl+ result.AudioPath,
            };
            return new SysResult<StudentCourseQuestionConfirmViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //============================================================================ 
        public SysResult ConfirmAnswer(StudentCourseQuestionAnswerConfirmViewModel viewModel, int currentUserId)
        {
            courseStudentQuestionsComponent.ConfirmAnswer(viewModel, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseStudentQuestionsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
