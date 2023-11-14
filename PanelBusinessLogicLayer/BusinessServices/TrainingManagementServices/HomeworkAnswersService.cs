using Common.Functions;
using Common.Objects;
using DataModels.HomeworksModels;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
   public class HomeworkAnswersService : IDisposable
    {
        private HomeworkAnswersComponent homeworkAnswersComponent;
        //===============================================================================
        public HomeworkAnswersService()
        {
            homeworkAnswersComponent = new HomeworkAnswersComponent();
        }
        //===============================================================================
        public SysResult Read(int homeworkId)
        {
            var result = homeworkAnswersComponent.Read(homeworkId).Select(c => new HomeworkAnswersViewModel()
            {
                Id = c.Id,
                HomeworkName = c.HomeWork.Title,
                StudentUserName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                GradeName = c.Grade != null ?  c.Grade.ToString() : "ثبت نشده"
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult<HomeworkAnswersViewModel> Find(int id)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var result = homeworkAnswersComponent.Find(id);
            var model = new HomeworkAnswersViewModel()
            {
                Id = result.Id,
                HomeworkName = result.HomeWork.Title,
                StudentUserName = result.StudentUser.FirstName + " " + result.StudentUser.LastName,
                StudentUserId = result.StudentUserId,
                HomeworkId = result.HomeWorkId,
                Description = result.Description,
                FilePath = cdnUrl + result.FilePath,
                Grade = result.Grade
            };
            return new SysResult<HomeworkAnswersViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult Update(HomeworkAnswersViewModel request, int currentUserId)
        {
            var model = new HomeworkAnswersModel()
            {
                Id = request.Id,
                Description = request.Description,
                StudentUserId  = request.StudentUserId,
                HomeWorkId = request.HomeworkId,
                Grade = request.Grade
            };
            homeworkAnswersComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };

        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            homeworkAnswersComponent.Delete(Ids);
            //**********************************************
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //=============================================================================== Disposing
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
            homeworkAnswersComponent?.Dispose();
        }
        #endregion
    }
}
