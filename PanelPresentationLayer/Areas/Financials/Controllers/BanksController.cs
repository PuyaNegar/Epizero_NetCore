using System;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelViewModels.FinancialsViewModels;
using PanelViewModels.BaseViewModels;
using System.Collections.Generic;

namespace PanelPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class BanksController : Controller
    {
        private BanksService banksService;
        //===========================================================================
        public BanksController()
        {
            this.banksService = new BanksService();
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
                var sysResult = banksService.Read();
                var result = sysResult.GetGridData<BanksViewModel>
                (request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BanksViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = banksService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = banksService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] BanksViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = banksService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        } 
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = banksService.Delete(viewModel);
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
            banksService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
