using System;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelViewModels.FinancialsViewModels;
using PanelViewModels.BaseViewModels;

namespace PanelPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class StudentFinancialReturnPaymentsController : Controller
    {
        private StudentFinancialReturnPaymentsService studentFinancialReturnPaymentsService;
        //===========================================================================
        public StudentFinancialReturnPaymentsController()
        {
            studentFinancialReturnPaymentsService = new   StudentFinancialReturnPaymentsService();
        }  
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StudentFinancialReturnPaymentsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentFinancialReturnPaymentsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentFinancialReturnPaymentsService.Find(viewModel.Id.Value );
                return Json(result);
            });
        }
        //==========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentFinancialReturnPaymentsService.Delete(viewModel);
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
            studentFinancialReturnPaymentsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
