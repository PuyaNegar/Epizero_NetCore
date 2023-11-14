using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Extentions;
using Microsoft.AspNetCore.Mvc;
using WebBusinessLogicLayer.BusinessServices.ContentsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebViewModels.ContentsViewModels;

namespace WebPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class BlogsController : Controller, IDisposable
    {
        private BlogsService blogsService;
        //========================================================================================
        public BlogsController()
        {
            blogsService = new BlogsService();
        }
        //=========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                
                int? blogGroupId = string.IsNullOrEmpty(Request.Query["BlogGroupId"]) ? (int?)null : Request.Query["BlogGroupId"].ToString().ToIntegerIdentifier();

                ViewBag.blogs = GetBlogs(blogGroupId);
                if (blogGroupId != null)
                    ViewBag.GroupTitle = GeBlogGroupTitle(blogGroupId);




                ViewBag.BlogGroups = GetBlogGroupsTask();
                ViewBag.LastBlogs = blogsService.Read(countTakeBlogs: 3).Value;
                return View();
            });
        }
        //=========================================================================
        List<BlogsViewModel> GetBlogs(int? blogGroupId)
        {
            using (var blogs = new BlogsService())
            {
                return blogs.Read(blogGroupId: blogGroupId).Value;
            }
        }

        //=========================================================================
        private string GeBlogGroupTitle(int? blogGroupId)
        {
            using (var blogGroupsService = new BlogGroupsService())
            {
                return blogGroupsService.Find(blogGroupId.Value).Value.Title;
            }
        }
        //=============================================================================================
        List<BlogGroupsViewModel> GetBlogGroupsTask()
        {
            using (var blogGroupsService = new BlogGroupsService())
            {
                return blogGroupsService.Read().Value;
            }
        }
    }
}