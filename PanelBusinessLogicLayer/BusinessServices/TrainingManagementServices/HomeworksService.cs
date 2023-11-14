using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Extentions;
using DataModels.HomeworksModels;
using PanelViewModels.BaseViewModels;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class HomeworksService : IDisposable
    {
        private HomeworksComponent homeworksComponent;
        //===============================================================================
        public HomeworksService()
        {
            homeworksComponent = new HomeworksComponent();
        }
        //===============================================================================
        public SysResult Read(int CourseMeetingId)
        {
            var result = homeworksComponent.Read(CourseMeetingId).Select(c => new HomeworksViewModel()
            {
                Id = c.Id,
                ExpiredDate = c.ExpiredDate.ToLocalDateTimeShortFormatString(),
                RegDateTime = c.RegDateTime.ToLocalDateTimeShortFormatString(),
                Title = c.Title,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
                CourseMeetingName = c.CourseMeeting.Name,
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult Add(HomeworksViewModel request, int currentUserId)
        {
            var model = new HomeworksModel()
            {
                Description = request.Description,
                Title = request.Title,
                ExpiredDate = request.ExpiredDate.ToDate().ToUtcDateTime(),
                CourseMeetingId = request.CourseMeetingId,
                FilePath = request.FilePath,
                IsActive = request.IsActive.ToBoolean(),
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId
            };
            homeworksComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }

        //===============================================================================
        public SysResult<HomeworksViewModel> Find(int id)
        {
            var result = homeworksComponent.Find(id);
            var model = new HomeworksViewModel()
            {
                Id = result.Id,
                CourseMeetingName = result.CourseMeeting.Name,
                CourseMeetingId =result.CourseMeetingId,
                Title = result.Title,
                IsActive = result.IsActive.ToActiveStatus(),
                ExpiredDate= result.ExpiredDate.ToDateShortFormatString(),
                Description = result.Description,
                FilePath = result.FilePath
            };
            return new SysResult<HomeworksViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult Update(HomeworksViewModel request, int currentUserId)
        {
            var model = new HomeworksModel()
            {
                Id = request.Id,
                Description = request.Description,
                Title = request.Title,
                IsActive = request.IsActive.ToBoolean(),
                ExpiredDate = request.ExpiredDate.ToDate().ToUtcDateTime(),
                CourseMeetingId = request.CourseMeetingId,
                FilePath = request.FilePath
            };
            homeworksComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };

        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            homeworksComponent.Delete(Ids);
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
            homeworksComponent?.Dispose();
        }
        #endregion
    }
}
