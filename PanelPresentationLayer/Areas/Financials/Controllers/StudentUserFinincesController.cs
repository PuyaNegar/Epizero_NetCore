using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelViewModels.FinancialsViewModels;

namespace PanelPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class StudentUserFinincesController : Controller
    {
        private StudentUserFinincesService studentUserFinincesService;
        //===========================================================================
        public StudentUserFinincesController()
        {
            studentUserFinincesService = new StudentUserFinincesService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<JsonResult>(() =>
            {
                dynamic requestData = request.Filters.ToFilterExpression();
                string TelNo = Convert.ToString(requestData["UserTelNo"]);
                var sysResult = studentUserFinincesService.Read(TelNo);
                var result = sysResult.GetGridData<StudentUserFinancialTransactionsViewModel>
                    (request);
                return Json(result);
            });
        }
        //=======================================================
        [HttpPost]
        public async Task<JsonResult> GetBalance(string Id)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentUserFinincesService.GetBalance(Id);
                return Json(result);
            });
        }
        //========================================================
        [HttpPost]
        public async Task<JsonResult> ChangeCredit([FromBody] ChangeCreditViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            { 
                var result = studentUserFinincesService.ChangeCredit(viewModel , GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        public int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.ToList()[1].Value);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentUserFinincesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
