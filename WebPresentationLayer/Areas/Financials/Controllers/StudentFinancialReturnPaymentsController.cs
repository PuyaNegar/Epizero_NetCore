using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System; 
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.FinancialsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;

namespace WebPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class StudentFinancialReturnPaymentsController : Controller
    {
        private StudentFinancialReturnPaymentsService studentFinancialSummaryService;
        //==========================================================================
        public StudentFinancialReturnPaymentsController()
        {
            studentFinancialSummaryService = new  StudentFinancialReturnPaymentsService();
        } 
        //==========================================================================
        [ApiService]
        [HttpGet]
        public async Task<IActionResult> Find(int Id)
        { 
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentFinancialSummaryService.Find(Id,GetCurrentUserId());
                return Json(result);
            });
        } 
        //=======================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
        //=======================================================
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentFinancialSummaryService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
