using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class TeacherSattlementSchedulesController : Controller
    {
        private TeacherSattlementSchedulesService teachercheckoutSchedulesService;
        //===========================================================================
        public TeacherSattlementSchedulesController()
        {
            this.teachercheckoutSchedulesService = new TeacherSattlementSchedulesService();
        }
        //===========================================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.TeacherPaymentMethodId = Id;
                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teachercheckoutSchedulesService.Read(Id);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> AddSattlement([FromBody] TeacherSattlementsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teachercheckoutSchedulesService.AddSattlement(viewModel);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TeacherSattlementSchedulesViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teachercheckoutSchedulesService.Add(viewModel , GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teachercheckoutSchedulesService.Delete(viewModel);
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
            teachercheckoutSchedulesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
