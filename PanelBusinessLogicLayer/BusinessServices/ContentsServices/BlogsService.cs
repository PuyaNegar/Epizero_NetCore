using System;
using System.Collections.Generic;
using System.Linq;
using Common.Objects;
using DataModels.ContentsModels;
using PanelBusinessLogicLayer.BusinessComponents.ContentsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.ContentsViewModels;

namespace PanelBusinessLogicLayer.BusinessServices.ContentManagementServices
{
    public class BlogsService : IDisposable
    {
        private BlogsComponent blogsComponent;
        //===============================================================================
        public BlogsService()
        {
            blogsComponent = new BlogsComponent();
        }
        //===============================================================================
        public SysResult Add(BlogsViewModel request, int currentUserId)
        {
            var model = new BlogsModel()
            {
                Title = request.Title,
                Text = request.Text,
                PicPath = request.PicPath,
                ModUserId = currentUserId,
                RegDateTime = DateTime.UtcNow,
                BlogGroupId = request.BlogGroupId
            };
            blogsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //===============================================================================
        public SysResult Read()
        {
            var result = blogsComponent.Read();
            var viewModel = result.Select(c => new BlogsViewModel()
            {
                Id = c.Id,
                Text = c.Text,
                PicPath = c.PicPath,
                Title = c.Title,
                BlogGroupName = c.BlogGroups.Title
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===============================================================================
        public SysResult<BlogsViewModel> Find(int id)
        {
            var result = blogsComponent.Find(id);
            var viewModel = new BlogsViewModel()
            {
                Id = result.Id,
                Text = result.Text,
                PicPath = result.PicPath,
                Title = result.Title,
                BlogGroupId = result.BlogGroupId
            };
            return new SysResult<BlogsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===============================================================================
        public SysResult Update(BlogsViewModel request, int currentUserId)
        {
            var model = new BlogsModel()
            {
                Id = request.Id,
                ModDateTime = DateTime.UtcNow,
                Title = request.Title,
                Text = request.Text,
                PicPath = request.PicPath,
                ModUserId = currentUserId,
                BlogGroupId = request.BlogGroupId
            };
            blogsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(c => new BlogsModel()
            {
                Id = c.Id.Value
            }).ToList();
            blogsComponent.Delete(model);
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
            blogsComponent?.Dispose();
        }
        #endregion
    }
}
