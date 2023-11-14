using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
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
    public class StudentPosPaymentsController : Controller
    {
        private StudentPosPaymentsService studentPosPaymentsService;
        //============================================================================
        public StudentPosPaymentsController()
        {
            studentPosPaymentsService = new StudentPosPaymentsService();
        } 
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentPosPaymentsService.Find(Id);
                return Json(result);
            });
        } 
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Add([FromBody] StudentFinancialPosPaymentsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentPosPaymentsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentPosPaymentsService.Delete(viewModel);
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
            studentPosPaymentsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
