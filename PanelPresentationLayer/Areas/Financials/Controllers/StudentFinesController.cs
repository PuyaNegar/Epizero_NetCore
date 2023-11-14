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
    public class StudentFinesController : Controller
    {
        private StudentFinesService studentFinesService;
        //===========================================================================
        public StudentFinesController()
        {
             studentFinesService = new  StudentFinesService();
        }  
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StudentFinesViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentFinesService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentFinesService.Delete(viewModel, GetCurrentUserId());
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
            studentFinesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
