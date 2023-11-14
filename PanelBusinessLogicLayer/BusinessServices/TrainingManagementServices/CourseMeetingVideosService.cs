using Common.Extentions;
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
    public class CourseMeetingVideosService : IDisposable
    {
        private CourseMeetingVideosComponent courseMeetingVideosComponent;
        //===============================================================================
        public CourseMeetingVideosService()
        {
            courseMeetingVideosComponent = new CourseMeetingVideosComponent();
        }

        //===============================================================================
        public SysResult Read(int CourseId)
        {
            var result = courseMeetingVideosComponent.Read(CourseId).Select(c => new CourseMeetingVideosViewModel()
            {
                Id = c.Id,
                Link = c.Link,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
                Title = c.Title,
                CourseMeetingName = c.CourseMeeting.Name,
                UserEditor = c.ModDateTime != null ? c.ModUser.FirstName + " " + c.ModUser.LastName + "(" + c.ModDateTime.Value.ToLocalDateTimeShortFormatString() + ")" : c.ModUser.FirstName + " " + c.ModUser.LastName + "(" + c.RegDateTime.ToLocalDateTimeShortFormatString() + ")"
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult Add(CourseMeetingVideosViewModel request, int currentUserId)
        {
            var model = new CourseMeetingVideosModel()
            {
                BannerPicPath = request.BannerPicPath,
                Link = request.Link,
                //VideoUniqueId = request.VideoUniqueId,
                Description = request.Description,
                Title = request.Title,
                CourseMeetingId = request.CourseMeetingId,
                IsActive = request.IsActive.ToBoolean(),
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId
            };
            courseMeetingVideosComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }

        //===============================================================================
        public SysResult<CourseMeetingVideosViewModel> Find(int id)
        {
            var result = courseMeetingVideosComponent.Find(id);
            var model = new CourseMeetingVideosViewModel()
            {
                Id = result.Id,
                //VideoUniqueId = result.VideoUniqueId,
                CourseMeetingName = result.CourseMeeting.Name,
                Title = result.Title,
                Description = result.Description,
                Link = result.Link,
                BannerPicPath = result.BannerPicPath,
                IsActive = result.IsActive.ToActiveStatus(),
            };
            return new SysResult<CourseMeetingVideosViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult Update(CourseMeetingVideosViewModel request, int currentUserId)
        {
            var model = new CourseMeetingVideosModel()
            {
                Id = request.Id,
                BannerPicPath = request.BannerPicPath,
                //VideoUniqueId = request.VideoUniqueId,
                Link = request.Link,
                Description = request.Description,
                Title = request.Title,
                CourseMeetingId = request.CourseMeetingId,
                IsActive = request.IsActive.ToBoolean(),
            };
            courseMeetingVideosComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };

        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            courseMeetingVideosComponent.Delete(Ids);
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
            courseMeetingVideosComponent?.Dispose();
        }
        #endregion
    }
}
