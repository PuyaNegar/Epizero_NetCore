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
    public class StudentDiscountsController : Controller
    {
        private StudentDiscountsService studentDiscountsService;
        //============================================================================
        public StudentDiscountsController()
        {
            studentDiscountsService = new StudentDiscountsService();
        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody] StudentDiscountsViewModel viewModel, int Id)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentDiscountsService.Update(studentFinancialDebtId: Id, viewModel, CurrentContext.GetCurrentUserId(this));
                return Json(result);
            });
        }
        //============================================= Disposing 
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentDiscountsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
