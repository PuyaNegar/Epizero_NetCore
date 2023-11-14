using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Interface;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelBusinessLogicLayer.BusinessServices.ContentManagementServices;
using PanelViewModels.ContentsViewModels;
using PanelBusinessLogicLayer.BusinessServices.ContentsServices;

namespace PanelPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class AboutUsController : Controller, IDisposable, ICurrentUser
    {
        private AboutUsService aboutUsService;
        //===========================================================================
        public AboutUsController()
        {
            this.aboutUsService = new AboutUsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
               
                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = aboutUsService.Read();
                var result = sysResult.GetGridData<AboutUsViewModel>
                    (request);
                return Json(result);
            });

        } 
        //=========================================================================
        [HttpPost]
        public async Task<JsonResult> UpdateDescription([FromBody] AboutUsDescriptionViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = aboutUsService.UpdateDescription(viewModel.Id, viewModel.Description, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = aboutUsService.Find(viewModel.Id.Value);
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody]  AboutUsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = aboutUsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        } 
        //===========================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            aboutUsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
