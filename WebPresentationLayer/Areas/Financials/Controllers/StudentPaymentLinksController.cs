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
    public class StudentPaymentLinksController : Controller
    {
        private StudentPaymentLinksService studentPaymentLinksService;
        private StudentUserFinincesService studentUserFinincesService;
        public StudentPaymentLinksController()
        {
            studentPaymentLinksService = new StudentPaymentLinksService();
            studentUserFinincesService = new StudentUserFinincesService();
        }
        //=======================================================
        public IActionResult Index()
        {
            ViewBag.Balance = studentUserFinincesService.GetBalance(GetCurrentUserId()).Value.Balance;
            ViewBag.StudentPaymentLinks = studentPaymentLinksService.Read(GetCurrentUserId()).Value;
            return View();
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
            studentPaymentLinksService?.Dispose();
            studentUserFinincesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
