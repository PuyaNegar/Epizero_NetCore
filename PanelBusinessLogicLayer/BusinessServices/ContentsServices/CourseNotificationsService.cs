using Common.Extentions;
using Common.Objects;
using DataModels.ContentsModels;
using PanelBusinessLogicLayer.BusinessComponents.ContentsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.ContentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.ContentsServices
{
    public class CourseNotificationsService : IDisposable
    {
        private CourseNotificationsComponent courseNotificationsComponent;
        //===============================================================================
        public CourseNotificationsService()
        {
            courseNotificationsComponent = new CourseNotificationsComponent();
        }
        //===============================================================================
        public SysResult Add(CourseNotificationsViewModel request, int currentUserId)
        {
            request.CourseNotificationIds = request.CourseNotificationIds ?? new List<string>();
            var _fromDate = new DateTime(request.FromDate.ToDate().Year, request.FromDate.ToDate().Month, request.FromDate.ToDate().Day, 0, 0, 0).ToUtcDateTime();
            var _toDate = new DateTime(request.ToDate.ToDate().Year, request.ToDate.ToDate().Month, request.ToDate.ToDate().Day, 0, 0, 0).ToUtcDateTime();
            var model = new NotificationsModel()
            {
                Title = request.Title,
                IsActive = request.IsActive.ToBoolean(),
                Description = request.Description,
                FromDate = _fromDate,
                ToDate = _toDate,
                ModUserId = currentUserId,
                RegDateTime = DateTime.UtcNow
            };
            var courseNotificationsModel = request.CourseNotificationIds.Select(item => new CourseNotificationsModel
            {
                 NotificationId= model.Id,
                CourseId = Convert.ToInt32(item),
            }).ToList();
            model.CourseNotifications = courseNotificationsModel;
            courseNotificationsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //===============================================================================
        public SysResult Read()
        {
            var result = courseNotificationsComponent.Read();
            var viewModel = result.Select(c => new CourseNotificationsViewModel()
            {
                Id = c.Id,
                IsActiveName = c.IsActive ? "فعال" : "غیرفعال",
                Description = c.Description,
                FromDate = c.FromDate.ToLocalDateLongFormatString(),
                ToDate = c.ToDate.ToLocalDateLongFormatString(),
                Title = c.Title

            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===============================================================================
        public SysResult<CourseNotificationsViewModel> Find(int id)
        {
            var result = courseNotificationsComponent.Find(id);
            var _courseNotificationIds = result.CourseNotifications.Select(c => c.CourseId.ToString()).ToList<string>();
            var viewModel = new CourseNotificationsViewModel()
            {
                Id = result.Id,
                Description = result.Description,
                IsActive = result.IsActive.ToActiveStatus(),
                FromDate = result.FromDate.ToLocalDateTime().ToDateShortFormatString(),
                ToDate = result.ToDate.ToLocalDateTime().ToDateShortFormatString(),
                Title = result.Title,
                CourseNotificationIds = _courseNotificationIds
            };
            return new SysResult<CourseNotificationsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===============================================================================
        public SysResult Update(CourseNotificationsViewModel request, int currentUserId)
        {
            request.CourseNotificationIds = request.CourseNotificationIds ?? new List<string>();
            var _fromDate = new DateTime(request.FromDate.ToDate().Year, request.FromDate.ToDate().Month, request.FromDate.ToDate().Day, 0, 0, 0).ToUtcDateTime();
            var _toDate = new DateTime(request.ToDate.ToDate().Year, request.ToDate.ToDate().Month, request.ToDate.ToDate().Day, 0, 0, 0).ToUtcDateTime();
            var model = new NotificationsModel()
            {
                Id = request.Id,
                ModDateTime = DateTime.UtcNow,
                Title = request.Title,
                Description = request.Description,
                FromDate = _fromDate,
                ToDate = _toDate,
                IsActive = request.IsActive.ToBoolean(),
                ModUserId = currentUserId,
            };
            var courseNotificationsModel = request.CourseNotificationIds.Select(item => new CourseNotificationsModel
            {
                NotificationId = model.Id,
                CourseId = Convert.ToInt32(item),
            }).ToList();
            model.CourseNotifications = courseNotificationsModel;
            courseNotificationsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(c => new NotificationsModel()
            {
                Id = c.Id.Value
            }).ToList();
            courseNotificationsComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //========================================================================
        public SysResult<CourseNotificationsViewModel> FindDescription(int Id)
        {
            var result = courseNotificationsComponent.FindDescription(Id);
            var viewModel = new CourseNotificationsViewModel()
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description
            };
            return new SysResult<CourseNotificationsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //====================================================================
        public SysResult UpdateDescription(int Id, string Description, int CurrentUserId)
        {
            courseNotificationsComponent.UpdateDescription(Id, Description.CharacterAnalysis(), CurrentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseNotificationsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
