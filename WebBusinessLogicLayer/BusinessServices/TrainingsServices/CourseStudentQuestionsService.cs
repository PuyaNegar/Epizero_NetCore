using Common.Objects;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.TrainingsServices
{
    public class CourseStudentQuestionsService : IDisposable
    {
        private CourseStudentQuestionsComponent courseStudentQuestionsComponent;
        public CourseStudentQuestionsService()
        {
            courseStudentQuestionsComponent = new CourseStudentQuestionsComponent();
        }
        //================================================
        public SysResult<List<CourseStudentQuestionsViewModel>> Read(int courseId, int? studentUserId, bool isShowNoVerifiedQuestion)
        {
            var result = courseStudentQuestionsComponent.Read(courseId, studentUserId, isShowNoVerifiedQuestion);
            return new SysResult<List<CourseStudentQuestionsViewModel>>() { IsSuccess = true, Value = result, Message = SystemCommonMessage.InformationFetchedSuccessfully };
        }
        //=================================================================================
        public SysResult Add(AddCourseStudentQuestionsViewModel viewModel, int currentUserId)
        {
            var model = new CourseStudentQuestionsModel()
            {
                CourseId = viewModel.CourseId,
                ModUserId = currentUserId,
                RegDateTime = DateTime.UtcNow,
                QuestionContext = viewModel.Context,
                QuestionPicPath = viewModel.QuestionPicPath,
                AudioPath = viewModel.AudioPath,
                QuestionFilePath = viewModel.QuestionFilePath,
                StudentUserId = currentUserId,
                IsVerified = (bool?)null,
                VerifiedDateTime = (DateTime?)null
            };
            courseStudentQuestionsComponent.Add(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult AddAnswer(AddCourseStudentQuestionAnswersViewModel viewModel, int currentUserId)
        {
            var model = new CourseStudentQuestionAnswersModel()
            {
                AnswerContext = viewModel.AnswerContext,
                AnsweredUserId = currentUserId,
                ModUserId = currentUserId,
                StudentQuestionId = viewModel.StudentQuestionId,
                AnswerPicPath = viewModel.AnswerPicPath,
                AnswerFilePath = viewModel.AnswerFilePath,
                AudioPath= viewModel.AudioPath,
                IsBestAnswer = false,
                IsVerified = false,
                RegDateTime = DateTime.UtcNow,
            };
            courseStudentQuestionsComponent.AddAnswer(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //================================================================================= Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseStudentQuestionsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
