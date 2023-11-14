using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
   public class CourseMeetingBookletsService : IDisposable
    {
        private CourseMeetingBookletsComponent courseMeetingBookletsComponent;
        //===============================================================================
        public CourseMeetingBookletsService()
        {
            courseMeetingBookletsComponent = new CourseMeetingBookletsComponent();
        }

        //===============================================================================
        public SysResult Read(int CourseId)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var result = courseMeetingBookletsComponent.Read(CourseId).Select(c => new CourseMeetingBookletsViewModel()
            {
                Id = c.Id,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
                Title = c.Title,
                FilePath = cdnUrl + c.FilePath,
                CourseMeetingName = c.CourseMeeting.Name,
                UserEditor = c.ModDateTime != null ? c.ModUser.FirstName + " " + c.ModUser.LastName + "(" + c.ModDateTime.Value.ToLocalDateTimeShortFormatString() + ")" : c.ModUser.FirstName + " " + c.ModUser.LastName + "(" + c.RegDateTime.ToLocalDateTimeShortFormatString() + ")"
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult Add(CourseMeetingBookletsViewModel request, int currentUserId)
        {
            var model = new CourseMeetingBookletsModel()
            {
                FilePath = request.FilePath,
                Description = request.Description,
                Title = request.Title,
                CourseMeetingId = request.CourseMeetingId,
                IsActive = request.IsActive.ToBoolean(),
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId
            };
            courseMeetingBookletsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }

        //===============================================================================
        public SysResult<CourseMeetingBookletsViewModel> Find(int id)
        {
            var result = courseMeetingBookletsComponent.Find(id);
            var model = new CourseMeetingBookletsViewModel()
            {
                Id = result.Id,
                CourseMeetingName = result.CourseMeeting.Name,
                Title = result.Title,
                Description = result.Description,
                FilePath = result.FilePath,
                IsActive = result.IsActive.ToActiveStatus(),
            };
            return new SysResult<CourseMeetingBookletsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult Update(CourseMeetingBookletsViewModel request, int currentUserId)
        {
            var model = new CourseMeetingBookletsModel()
            {
                Id = request.Id,
                FilePath = request.FilePath,
                Description = request.Description,
                Title = request.Title,
                CourseMeetingId = request.CourseMeetingId,
                IsActive = request.IsActive.ToBoolean(),
            };
            courseMeetingBookletsComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };

        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            courseMeetingBookletsComponent.Delete(Ids);
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
            courseMeetingBookletsComponent?.Dispose();
        }
        #endregion
    }
}
