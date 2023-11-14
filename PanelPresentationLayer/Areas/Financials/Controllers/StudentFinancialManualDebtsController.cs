using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
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
    public class StudentFinancialManualDebtsController : Controller
    {
        private StudentFinancialManualDebtsService studentFinancialManualDebtsService;
        //================================================================= 
        public StudentFinancialManualDebtsController()
        {
            this.studentFinancialManualDebtsService = new StudentFinancialManualDebtsService();
        }
        //================================================================= 
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            });
        }
        //=================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StudentFinancialManualDebtsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentFinancialManualDebtsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentFinancialManualDebtsService.Delete(viewModel);
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
            studentFinancialManualDebtsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
