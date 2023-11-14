using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBusinessLogicLayer.BusinessServices.ContentsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebViewModels.BaseViewModels;
using WebViewModels.ContentsViewModels;

namespace WebPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    // [ApiService]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class SingleBlogController : Controller, IDisposable
    {
        private BlogsService blogsService;
        //========================================================================================
        public SingleBlogController()
        {
            blogsService = new BlogsService();
        }
        //=============================================================================================
        public async Task<IActionResult> Index([FromQuery] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                
                ViewBag.Blog = blogsService.Find(viewModel.Id.Value).Value;
                ViewBag.BlogGroups = GetBlogGroupsTask();
                ViewBag.LastBlogs = blogsService.Read(countTakeBlogs: 3).Value;
                return View();
            });
        }
        //=============================================================================================
        List<BlogGroupsViewModel> GetBlogGroupsTask()
        {
            using (var blogGroupsService = new BlogGroupsService())
            {
                return blogGroupsService.Read().Value;
            }
        }

        //================================================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            blogsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}