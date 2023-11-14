using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class PaidChequesController : Controller
    {
        private PaidChequesService paidChequesService;
        //===========================================================================
        public PaidChequesController()
        {
            paidChequesService = new PaidChequesService();
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
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<JsonResult>(() =>
            { 
                dynamic filter = request.Filters.ToFilterExpression();
                int chequesStatusTypeId =  Convert.ToInt32(filter.ChequesStatusTypeId);
                var sysResult = paidChequesService.Read(chequesStatusTypeId);
                var result = sysResult.GetGridData<PaidChequesViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = paidChequesService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Add([FromBody] PaidChequesViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = paidChequesService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] PaidChequesViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = paidChequesService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = paidChequesService.Delete(viewModel);
                return Json(result);
            });
        }


        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> GetRemainingAmount([FromBody]  IntegerIdentifierViewModel  viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = paidChequesService.GetRemainingAmount(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            paidChequesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
