using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
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
    public class StudentFinancialDebtsController : Controller
    {
        private StudentFinancialDebtsService studentFinancialDebtsService;
        //===========================================================================
        public StudentFinancialDebtsController()
        {
            this.studentFinancialDebtsService = new StudentFinancialDebtsService();
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentFinancialDebtsService.Delete(viewModel , GetCurrentUserId());
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
            studentFinancialDebtsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
