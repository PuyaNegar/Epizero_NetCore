using System;
using System.Collections.Generic;
using System.Linq;
using Common.Objects;
 
using WebBusinessLogicLayer.BusinessComponents.ContentsComponents;
using WebViewModels.ContentsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.ContentsServices
{
    public class BlogGroupsService : IDisposable
    {
        private BlogGroupsComponent blogGroupsComponent;
        //============================================================
        public BlogGroupsService()
        {
            blogGroupsComponent = new BlogGroupsComponent();
        }
        //===============================================================================
        public SysResult<List<BlogGroupsViewModel>> Read()
        {
            var result = blogGroupsComponent.Read();
            var viewModel = result.Select(c => new BlogGroupsViewModel()
            {
                Id = c.Id,
                Title = c.Title
            }).ToList();
            return new SysResult<List<BlogGroupsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //============================================================
        public SysResult<BlogGroupsViewModel> Find(int id)
        {
            var result = blogGroupsComponent.Find(id);
            var viewModel = new BlogGroupsViewModel()
            {
                Id = result.Id,
                Title = result.Title,
            };
            return new SysResult<BlogGroupsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
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
