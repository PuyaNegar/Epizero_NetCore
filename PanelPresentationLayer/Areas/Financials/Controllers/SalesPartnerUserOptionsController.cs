using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class SalesPartnerUserOptionsController : Controller
    {
        private SalesPartnerUserOptionsService salesPartnerUserOptionsService;
        //===========================================================================
        public SalesPartnerUserOptionsController()
        {
            this.salesPartnerUserOptionsService = new SalesPartnerUserOptionsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var courseService = new CoursesService())
                {
                    ViewBag.Courses = courseService.ReadForComboBox().Value;
                }
                using (var salesPartnerUsersService = new SalesPartnerUsersService())
                {
                    ViewBag.SalesPartnerUsers = salesPartnerUsersService.ReadForComboBox().Value;
                }
                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                dynamic filter = request.Filters.ToFilterExpression();
                int salePartnerUserId = filter.SalePartnerUserId == null ? 0 : filter.SalePartnerUserId;
                var sysResult = salesPartnerUserOptionsService.Read(salePartnerUserId);
                var result = sysResult.GetGridData<SalesPartnerUserOptionsViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SalesPartnerUserOptionsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = salesPartnerUserOptionsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = salesPartnerUserOptionsService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] SalesPartnerUserOptionsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = salesPartnerUserOptionsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = salesPartnerUserOptionsService.Delete(viewModel);
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
            salesPartnerUserOptionsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
