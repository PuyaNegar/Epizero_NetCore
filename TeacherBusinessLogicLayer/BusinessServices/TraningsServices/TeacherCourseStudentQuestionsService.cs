using Common.Enums;
using Common.Objects; 
using System;
using System.Linq;
using Common.Extentions;
using DataModels.TrainingManagementModels;
using TeacherBusinessLogicLayer.BusinessComponents.TraningsComponents;
using TeacherViewModels.TraningsViewModels;

namespace TeacherBusinessLogicLayer.BusinessServices.TraningsServices
{
    public class TeacherCourseStudentQuestionsService : IDisposable
    {
        private TeacherCourseStudentQuestionsComponent courseStudentQuestionsComponent;
        //===============================================================================
        public TeacherCourseStudentQuestionsService()
        {
            courseStudentQuestionsComponent = new TeacherCourseStudentQuestionsComponent();
        }
        //===============================================================================
        public SysResult Read(  int  CourseId , int currentUserId)
        {
            var result = courseStudentQuestionsComponent.Read(   CourseId , currentUserId).Select(c => new TeacherStudentCourseQuestionsViewModel()
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
        public SysResult AddAnswers(TeacherStudentCourseQuestionAnswersViewModel viewModel, int currentUserId)
        {
            var model = new CourseStudentQuestionAnswersModel()
            {
                AnswerContext = viewModel.AnswerContext,
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
                IsBestAnswer = true,
                AnsweredUserId = currentUserId,
                IsVerified = true,
                VerifiedDateTime = DateTime.UtcNow,
                StudentQuestionId = viewModel.QuestionId,
            };
            courseStudentQuestionsComponent.AddAnswers(model , currentUserId);
            return new SysResult () { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded, };
        }
        //============================================================================ 
        public SysResult RejectAnswer(TeacherStudentCourseQuestionsRejectViewModel viewModel, int currentUserId)
        {
            courseStudentQuestionsComponent.RejectAnswer(viewModel, currentUserId);
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
