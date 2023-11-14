using Common.Extentions;
using Common.Objects;
using DataModels.ContentsModels;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class CourseSampleVideosService : IDisposable
    {
        private CourseSampleVideosComponent courseSampleVideosComponent;
        //=================================================================================
        public CourseSampleVideosService()
        {
            this.courseSampleVideosComponent = new CourseSampleVideosComponent();
        }
        //=================================================================================
        public SysResult Read(int CourseId)
        {
            var result = courseSampleVideosComponent.Read(CourseId);
            var viewModel = result.Select(c => new CourseSampleVideosViewModel()
            {
                Id = c.Id,
                CourseName = c.Course.Name,
                Inx = c.Inx,
                Title = c.Title,
                IsActiveName = c.IsActive ? "فعال" : "غیرفعال",
                UserEditor = c.ModDateTime != null ? c.ModUser.FirstName + " " + c.ModUser.LastName + "(" + c.ModDateTime.Value.ToLocalDateTimeShortFormatString() + ")" : c.ModUser.FirstName + " " + c.ModUser.LastName + "(" + c.RegDateTime.ToLocalDateTimeShortFormatString() + ")"
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };

        }
        //=================================================================================
        public SysResult Add(CourseSampleVideosViewModel viewModel, int CurrentUserId)
        {

            var model = new CourseSampleVideosModel()
            {
                Id = viewModel.Id,
                CourseId = viewModel.CourseId,
                Inx = viewModel.Inx,
                Title = viewModel.Title,
                Link = viewModel.Link,
                IsActive = viewModel.IsActive.ToBoolean(),
                RegDateTime = DateTime.UtcNow,
                ModUserId = CurrentUserId,
            };
            courseSampleVideosComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<CourseSampleVideosViewModel> Find(int Id)
        {
            var result = courseSampleVideosComponent.Find(Id);
            var viewModel = new CourseSampleVideosViewModel()
            {
                Id = result.Id,
                Inx = result.Inx,
                Link = result.Link,
                Title = result.Title,
                CourseId = result.CourseId,
                IsActive = result.IsActive.ToActiveStatus(),
            };
            return new SysResult<CourseSampleVideosViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(CourseSampleVideosViewModel viewModel, int UserId)
        {

            var model = new CourseSampleVideosModel()
            {
                Id = viewModel.Id,
                Inx = viewModel.Inx,
                Link = viewModel.Link,
                Title = viewModel.Title,
                CourseId = viewModel.CourseId,
                ModUserId = UserId,
                IsActive = viewModel.IsActive.ToBoolean(),
            };
            courseSampleVideosComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(a => new CourseSampleVideosModel()
            {
                Id = a.Id.Value,
            }).ToList();
            courseSampleVideosComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //===================================================================Disposing
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
            courseSampleVideosComponent?.Dispose();
        }
        #endregion
    }
}
