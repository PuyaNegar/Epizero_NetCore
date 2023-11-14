using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.ContentsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.ContentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class HomePageNotificationsController : Controller
    {
        private HomePageNotificationsService homePageNotificationsService;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public HomePageNotificationsController()
        {
            homePageNotificationsService = new HomePageNotificationsService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {

                return View();
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = homePageNotificationsService.Read();
                var result = sysResult.GetGridData<HomePageNotificationsViewModel>
                    (request);
                return Json(result);
            });

        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public async Task<IActionResult> Find()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = homePageNotificationsService.Find();
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] HomePageNotificationsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = homePageNotificationsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            homePageNotificationsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
