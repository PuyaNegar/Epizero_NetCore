using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using System;
using Microsoft.AspNetCore.Authorization;
using PanelPresentationLayer.Infrastracture.Filters;
using Common.Objects;
using PanelViewModels.FinancialsViewModels;
using Common.Extentions;
using PanelViewModels.OrderViewModels;
using PanelPresentationLayer.Infrastracture.Functions;

namespace PanelPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [SalesPartnerPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class CurrentSalesPartnerUserSharesController : Controller
    {
        private SalesPartnerUserSharesService salesPartnerUserSharesService;
        //=============================================
        public CurrentSalesPartnerUserSharesController()
        {
            salesPartnerUserSharesService = new SalesPartnerUserSharesService(); 
        }
        //=============================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            });
        }
        //=============================================
        public async Task<JsonResult> Read( [FromForm] DataTableRequest request)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = salesPartnerUserSharesService.Read(CurrentContext.GetCurrentUserId(this)).GetGridData<SalesPartnerUserSharesViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] FinalizedOrdersViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = salesPartnerUserSharesService.Find(viewModel.Id);
                return Json(result);
            });
        }
        //============================================= Disposing 
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            salesPartnerUserSharesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
