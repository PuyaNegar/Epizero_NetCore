using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extentions;
using Common.Objects;
using DataModels.ContentsModels;
using PanelBusinessLogicLayer.BusinessComponents.ContentsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.ContentsViewModels;

namespace PanelBusinessLogicLayer.BusinessServices.ContentsServices
{
    public class BlogGroupsService : IDisposable
    {
        private BlogGroupsComponent blogGroupsComponent;
        //===============================================================================
        public BlogGroupsService()
        {
            blogGroupsComponent = new BlogGroupsComponent();
        }
        //===============================================================================
        public SysResult Add(BlogGroupsViewModel request, int currentUserId)
        {
            var model = new BlogGroupsModel()
            {
                Title = request.Title,
                ModUserId = currentUserId,
                RegDateTime = DateTime.UtcNow,
                IsActive = request.IsActive.ToBoolean()
            };
            blogGroupsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //===============================================================================
        public SysResult Read()
        {
            var result = blogGroupsComponent.Read();
            var viewModel = result.Select(c => new BlogGroupsViewModel()
            {
                Id = c.Id,
                Title = c.Title,
                IsActiveName = c.IsActive ? "فعال" : "غیرفعال"
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===============================================================================
        public SysResult<BlogGroupsViewModel> Find(int id)
        {
            var result = blogGroupsComponent.Find(id);
            var viewModel = new BlogGroupsViewModel()
            {
                Id = result.Id,
                Title = result.Title,   
                IsActive = result.IsActive.ToActiveStatus()
            };
            return new SysResult<BlogGroupsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===============================================================================
        public SysResult Update(BlogGroupsViewModel request, int currentUserId)
        {
            var model = new BlogGroupsModel()
            {
                Id = request.Id,
                ModDateTime = DateTime.UtcNow,
                Title = request.Title,
                ModUserId = currentUserId,
                IsActive = request.IsActive.ToBoolean()
            };
            blogGroupsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(c => new BlogGroupsModel()
            {
                Id = c.Id.Value
            }).ToList();
            blogGroupsComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //===============================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = blogGroupsComponent.Read();
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Value = c.Id.ToString(),
                Text = c.Title,
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = "اطلاعات با موفقیت ثبت شد", Value = viewModel };
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
            blogGroupsComponent?.Dispose();
        }
        #endregion

    }
}
