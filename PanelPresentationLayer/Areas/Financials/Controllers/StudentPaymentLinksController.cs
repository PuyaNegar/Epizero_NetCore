using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
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
    public class StudentPaymentLinksController : Controller
    {
        private StudentPaymentLinksService studentPaymentLinksService;
        //================================================================== 
        public StudentPaymentLinksController()
        {
            this.studentPaymentLinksService = new StudentPaymentLinksService();
        }
        //================================================================== 
        public IActionResult Index()
        {
            return View();
        }
        //==================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                dynamic data = request.Filters.ToFilterExpression();
                bool isPaid = Convert.ToBoolean(data.IsPaid);
                var sysResult = studentPaymentLinksService.Read(isPaid);
                var result = sysResult.GetGridData<ReadStudentPaymentLinksViewModel>
                (request);
                return Json(result);
            });
        }
        //====================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //==============================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentPaymentLinksService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
