using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using WebBusinessLogicLayer.BusinessComponents.ContentsComponents;
using WebViewModels.ContentsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.ContentsServices
{
    public class BlogsService : IDisposable
    {
        private BlogsComponent blogsComponent;
        //==================================================================================================================================
        public BlogsService()
        {
            blogsComponent = new BlogsComponent();
        }
        //==================================================================================================================================
        public SysResult<List<BlogsViewModel>> Read(int? blogGroupId = null, int? countTakeBlogs = null)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var result = blogsComponent.Read(blogGroupId).OrderByDescending(c => c.RegDateTime).Select(c => new BlogsViewModel()
            {
                Id = c.Id,
                PicPath = cdnUrl + c.PicPath,
                Text = c.Text,
                Title = c.Title,
                BlogGroupId = c.BlogGroupId,
                BlogGroupName = c.BlogGroups.Title,

                RegDateTime = c.RegDateTime.ToLocalDateTimeLongFormatString()
            });
            var viewModel = countTakeBlogs != null ? result.Take(countTakeBlogs.Value).ToList() : result.ToList();
            return new SysResult<List<BlogsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }

        //==================================================================================================================================
        public SysResult<BlogsViewModel> Find(int id)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var result = blogsComponent.Find(id);
            var viewModel = new BlogsViewModel()
            {
                Id = result.Id,
                BlogGroupId = result.BlogGroupId,
                BlogGroupName = result.BlogGroups.Title,
                RegDateTime = result.RegDateTime.ToLocalDateTimeLongFormatString(),
                Title = result.Title,
                Text = result.Text,
                PicPath = cdnUrl + result.PicPath,
            };
            return new SysResult<BlogsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }

        //==================================================================================================================================
        public List<RssViewModel> ReadRss()
        {
            var result = blogsComponent.ReadRss();
            return result;
        }
        //===================================================================================================================== Dispise
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
                blogsComponent?.Dispose();
                return;
            }
        }
        #endregion
    }
}

