using System;
using Microsoft.AspNetCore.Mvc;
using Common.Extentions;
using Common.Enums;

namespace WebPresentationLayer.Controllers
{ 
    [Route("[controller]/[action]")]
    public class PaymentController : Controller , IDisposable
    {
        public PaymentController() { }
     
        //==================================================================================================
        public IActionResult SuccessOrderPayment()
        {
            var RefId = Request.Query["RefId"].ToString().DecriptWithDESAlgoritm().Split('~');
            ViewBag.DateTime = DateTime.UtcNow.ToLocalDateTimeLongFormatString();
            ViewBag.InvoiceProcessType = InvoiceProcessType.Order;
            ViewBag.InvoiveNo = RefId[0];
            ViewBag.HashOrderId = RefId[1];
            ViewBag.ReferenceId = RefId[2];
            return View("~/Views/Payment/SuccessPayment.cshtml");
        }
        //===================================================================================================
        public IActionResult ErrorOrderPayment()
        {
            ViewBag.InvoiceProcessType = InvoiceProcessType.Order;
            return View("~/Views/Payment/ErrorPayment.cshtml");
        } 
        //=============================================================================== Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}