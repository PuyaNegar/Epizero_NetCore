using System;
using System.Threading.Tasks;
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
    public class StudentFinancialChequePaymentsController : Controller
    {
        private StudentFinancialChequePaymentsService studentFinancialChequePaymentsService;
        //============================================================================
        public StudentFinancialChequePaymentsController()
        {
            studentFinancialChequePaymentsService = new StudentFinancialChequePaymentsService();
        }
        //============================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            });
        }

        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentFinancialChequePaymentsService.Find(viewModel.Id.Value);
                return Json(result);
            });
        } 
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Add([FromBody] StudentFinancialChequePaymentsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentFinancialChequePaymentsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }  
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentFinancialChequePaymentsService.Delete(viewModel);
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
            studentFinancialChequePaymentsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
