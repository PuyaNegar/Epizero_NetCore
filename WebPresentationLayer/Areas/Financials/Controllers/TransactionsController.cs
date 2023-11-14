using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBusinessLogicLayer.BusinessServices.FinancialsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.FinancialsViewModels;

namespace WebPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class TransactionsController : Controller
    {
        private StudentUserFinincesService studentUserFinincesService;
        private StudentUserScoresService studentUserScoresService;
        public TransactionsController()
        {
            studentUserFinincesService = new StudentUserFinincesService();
            studentUserScoresService = new StudentUserScoresService();
        }
        //=============================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.Balance = studentUserFinincesService.GetBalance(GetCurrentUserId()).Value.Balance;  
                ViewBag.Transactions   = studentUserFinincesService.Read(0, int.MaxValue, GetCurrentUserId()).Value;
                ViewBag.ScoresBalance = studentUserScoresService.GetBalance(CurrentContext.GetCurrentUserId(this).Value).Value.Balance;
                ViewBag.ScoresTransactions = studentUserScoresService.Read(CurrentContext.GetCurrentUserId(this).Value).Value;
                return View();
            });
        }
        //=======================================================
        //[HttpGet]
        //[ApiService]
        //public async Task<IActionResult> Read([FromQuery] TransactionsRequestViewModel request)
        //{
        //    return await Task.Run<IActionResult>(() =>
        //    {
        //        if (request == null)
        //            request = new TransactionsRequestViewModel { Page = 0 };
        //        var result = studentUserFinincesService.Read(request.Page, int.MaxValue, GetCurrentUserId());
        //        return Ok(result);
        //    });
        //}
        //=======================================================

        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
        //=======================================================
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentUserFinincesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
