using Common.Objects;
using DataModels.HomeworksModels;
using System;
using System.Collections.Generic;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.TrainingsServices
{
   public class HomeworksService : IDisposable
    {
        private HomeworksComponent homeworksComponent;
        public  HomeworksService()
        {
            homeworksComponent = new HomeworksComponent();
        }
        //===============================================================================
        public SysResult<List<StudentCourseGroupsViewModel>> ReadAllWithAverageGrade(int studentUserId)
        {
            var result = homeworksComponent.ReadAllWithAverageGrade(studentUserId); 
            return new SysResult<List<StudentCourseGroupsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult AddAnswer(HomeworkFilePathViewModel viewModel, int studentUserId)
        {

            var model = new HomeworkAnswersModel()
            {
                FilePath = viewModel.FilePath,
                Grade = null,
                HomeWorkId = viewModel.HomeWorkId,
                StudentUserId = studentUserId,
                RegDateTime = DateTime.UtcNow,
                ModUserId = studentUserId
            };
            homeworksComponent.AddAnswer(model , studentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
