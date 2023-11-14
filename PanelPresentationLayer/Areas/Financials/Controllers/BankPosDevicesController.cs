using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;

namespace PanelPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class BankPosDevicesController : Controller
    {
        private BankPosDevicesService bankPosDevicesService;
        //===========================================================================
        public BankPosDevicesController()
        {
            this.bankPosDevicesService = new BankPosDevicesService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var banksService = new BanksService())
                {
                    ViewBag.Banks = banksService.ReadForComboBox().Value;
                    return View();
                };
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = bankPosDevicesService.Read();
                var result = sysResult.GetGridData<BankPosDevicesViewModel>
                (request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BankPosDevicesViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = bankPosDevicesService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = bankPosDevicesService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] BankPosDevicesViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = bankPosDevicesService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = bankPosDevicesService.Delete(viewModel);
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
            bankPosDevicesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
