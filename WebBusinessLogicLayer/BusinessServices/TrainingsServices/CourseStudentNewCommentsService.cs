using Common.Objects;
using DataModels.TrainingManagementModels;
using System;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.TrainingsServices
{
    public class CourseStudentNewCommentsService : IDisposable
    {
        private CourseStudentNewCommentsComponent courseStudentNewCommentsComponent;
        public CourseStudentNewCommentsService()
        {
            courseStudentNewCommentsComponent = new CourseStudentNewCommentsComponent();
        }
         
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult AddStudentNewComments(AddNewCommetsViewModel viewModel , int studentUserId)
        {
            var model = new CourseStudentNewCommentsModel()
            {
                Comment = viewModel.Comment,
                Rate = viewModel.Rate == 0 ? null : viewModel.Rate,
                CourseId = viewModel.CourseId,
                StudentUserId = studentUserId,
                IsActive = false,
                RegDateTime = DateTime.UtcNow
            };
            courseStudentNewCommentsComponent.AddStudentNewComments(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseStudentNewCommentsComponent.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
