using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebPresentationLayer.Infrastracture.Filters;

namespace WebPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class PaymentsController : Controller
    {

        [Authorize]
        public async Task<IActionResult> SuccessPayment()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            }); 
        }
        //=======================================================================
        [Authorize]
        public async Task<IActionResult> ErrorPayment()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            }); 
        } 
        //===========================================================================
        void RemoveCartCookie()
        {
            Response.Cookies.Delete("CartHashId");
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}