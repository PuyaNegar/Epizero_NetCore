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
using PanelViewModels.FinancialsViewModels;

namespace PanelPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class StudentUserUsingDiscountCodesController : Controller
    {
        private DiscountCodesService discountCodesService;
        //===========================================================================
        public StudentUserUsingDiscountCodesController()
        {
            this.discountCodesService = new DiscountCodesService();
        }
        //===========================================================================
        public IActionResult Index(int Id)
        {
            ViewBag.DiscountCodeId = Id;
            return View();
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Read([FromForm] DataTableRequest request , int Id)
        {
            return await Task.Run<JsonResult>(() =>
            {
             
                var sysResult = discountCodesService.Readused(Id);
                var result = sysResult.GetGridData<StudentUserUsingDiscountCodesViewModel>
                    (request);
                return Json(result);
            });
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            discountCodesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
