using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class StudentFinancialSummaryController : Controller
    {
        private StudentFinancialSummaryService studentFinancialSummaryService;

        public StudentFinancialSummaryController()
        {
            studentFinancialSummaryService = new StudentFinancialSummaryService();
        }
        //==========================================================================
        [ApiService]
        [HttpGet]
        public async Task<IActionResult> Read()
        {
           
                return await Task.Run<IActionResult>(() =>
                {
                    var result = studentFinancialSummaryService.Read(GetCurrentUserId());
                    return Json(result);
                });
             
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
        //==========================================================================
        [ApiService]
        [HttpGet]
        public async Task<IActionResult> FindCheque(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentFinancialSummaryService.FindCheque(Id,GetCurrentUserId());
                return Json(result);
            });
        } 
        //==========================================================================
        //[ApiService]
        //[HttpGet]
        //public async Task<IActionResult> FindReturnPayment(int Id)
        //{
        //    return await Task.Run<IActionResult>(() =>
        //    {
        //        var result = studentFinancialSummaryService.FindReturnPayment(Id, GetCurrentUserId());
        //        return Json(result);
        //    });
        //}
        //==========================================================================
        [ApiService]
        [HttpGet]
        public async Task<IActionResult> FindPosPayment(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentFinancialSummaryService.FindPosPayment(Id, GetCurrentUserId());
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
