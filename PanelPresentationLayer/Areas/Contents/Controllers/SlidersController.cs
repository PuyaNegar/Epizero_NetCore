using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PanelPresentationLayer.Infrastracture.Filters; 
using PanelViewModels.BaseViewModels;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelBusinessLogicLayer.BusinessServices.ContentsServices;
using PanelViewModels.ContentsViewModels;

namespace PanelPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync] 
    [ExceptionHandlerAsync]
    public class SlidersController : Controller
    {
        private SlidersService slidersService;
        //===========================================================================
        public SlidersController()
        {
            this.slidersService = new SlidersService();
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
                var sysResult = slidersService.Read();
                var result = sysResult.GetGridData<SlidersViewModel>
                (request);
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SlidersViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = slidersService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = slidersService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody]  SlidersViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = slidersService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel) 
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = slidersService.Delete(viewModel);
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
            slidersService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
