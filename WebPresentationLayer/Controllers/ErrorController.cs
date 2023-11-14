using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebPresentationLayer.Controllers
{
    public class ErrorController : Controller
    {
        //===========================================================================================
        [Route("/Error/Page404")]
        public IActionResult Page404()
        {
            HttpContext.Response.StatusCode = 404;
            return View();
        }
        //===========================================================================================
        [Route("/Error/Page500")]
        public IActionResult Page500()
        {
            HttpContext.Response.StatusCode = 500;
            return View();
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