using Common.Extentions;
using Common.Objects;
using DataModels.ContentsModels;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
   public class CourseDescriptionVideosService : IDisposable
    {
        private CourseDescriptionVideosComponent courseDescriptionVideosComponent;
        //=================================================================================
        public CourseDescriptionVideosService()
        {
            this.courseDescriptionVideosComponent = new CourseDescriptionVideosComponent();
        }
        //=================================================================================
        public SysResult Read(int CourseId)
        {
            var result = courseDescriptionVideosComponent.Read(CourseId);
            var viewModel = result.Select(c => new CourseDescriptionVideosViewModel()
            {
                Id = c.Id,
                CourseName = c.Course.Name,
                Inx = c.Inx,
                Title = c.Title,
                IsActiveName = c.IsActive ? "فعال" : "غیرفعال"
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };

        }
        //=================================================================================
        public SysResult Add(CourseDescriptionVideosViewModel viewModel, int CurrentUserId)
        {

            var model = new CourseDescriptionVideosModel()
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
            courseDescriptionVideosComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<CourseDescriptionVideosViewModel> Find(int Id)
        {
            var result = courseDescriptionVideosComponent.Find(Id);
            var viewModel = new CourseDescriptionVideosViewModel()
            {
                Id = result.Id,
                Inx = result.Inx,
                Link = result.Link,
                Title = result.Title,
                CourseId = result.CourseId,
                IsActive = result.IsActive.ToActiveStatus(),
            };
            return new SysResult<CourseDescriptionVideosViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(CourseDescriptionVideosViewModel viewModel, int UserId)
        {

            var model = new CourseDescriptionVideosModel()
            {
                Id = viewModel.Id,
                Inx = viewModel.Inx,
                Link = viewModel.Link,
                Title = viewModel.Title,
                CourseId = viewModel.CourseId,
                ModUserId = UserId,
                IsActive = viewModel.IsActive.ToBoolean(),
            };
            courseDescriptionVideosComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(a => new CourseDescriptionVideosModel()
            {
                Id = a.Id.Value,
            }).ToList();
            courseDescriptionVideosComponent.Delete(model);
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
            courseDescriptionVideosComponent?.Dispose();
        }
        #endregion
    }
}
