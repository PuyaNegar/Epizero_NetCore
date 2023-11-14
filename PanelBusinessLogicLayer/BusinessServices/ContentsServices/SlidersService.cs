using Common.Extentions;
using Common.Objects;
using DataModels.ContentsModels;   
using PanelBusinessLogicLayer.BusinessComponents.ContentsComponents;
using PanelViewModels.BaseViewModels; 
using PanelViewModels.ContentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.ContentsServices
{
    public class SlidersService : IDisposable
    {
        private SlidersComponent slidersComponent;
        //=================================================================================
        public SlidersService()
        {
            this.slidersComponent = new SlidersComponent();
        }
        //=================================================================================
        public SysResult Read()
        {
            var result = slidersComponent.Read();
            var viewModel = result.Select(c => new SlidersViewModel()
            {
                Id = c.Id,
                Title = c.Title,
                Alt = c.Alt,
                Inx = c.Inx,
                Link = c.Link,
                Description = c.Description,
                IsActiveName = c.IsActive ? "فعال" : "غیرفعال"
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };

        }
        //=================================================================================
        public SysResult Add(SlidersViewModel viewModel, int CurrentUserId)
        {
            if (string.IsNullOrEmpty(viewModel.PicPath))
                throw new Exception("عکس اسلایدر را انتخاب کنید.");
            var model = new SlidersModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Alt = viewModel.Alt,
                PicPath = viewModel.PicPath,
                Inx = viewModel.Inx,
                RegDateTime = DateTime.UtcNow,
                Link = viewModel.Link,
                IsActive = viewModel.IsActive.ToBoolean(),
                ModUserId = CurrentUserId,
                Description = viewModel.Description
            };
            slidersComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<SlidersViewModel> Find(int Id)
        {
            var result = slidersComponent.Find(Id);
            var viewModel = new SlidersViewModel()
            {
                Id = result.Id,
                Title = result.Title,
                Alt = result.Alt,
                PicPath = result.PicPath,
                Inx = result.Inx,
                Link = result.Link,
                IsActive = result.IsActive.ToActiveStatus(),
                Description = result.Description
            };
            return new SysResult<SlidersViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(SlidersViewModel viewModel, int UserId)
        {
            if (string.IsNullOrEmpty(viewModel.PicPath))
                throw new Exception("عکس اسلایدر را انتخاب کنید.");

            var model = new SlidersModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Alt = viewModel.Alt,
                PicPath = viewModel.PicPath,
                Inx = viewModel.Inx,
                ModUserId = UserId,
                Link = viewModel.Link,
                IsActive = viewModel.IsActive.ToBoolean(),
                Description = viewModel.Description
            };
            slidersComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(a => new SlidersModel()
            {
                Id = a.Id.Value,
            }).ToList();
            slidersComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted};
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
            slidersComponent?.Dispose();
        }
        #endregion
    }
}
