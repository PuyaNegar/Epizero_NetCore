using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Common.Interface;
using Common.Extentions;
namespace PanelPresentationLayer.Controllers
{
    [Authorize]
    public class HomeController : Controller, ICurrentUser
    { 
        //=========================================================================================
        public IActionResult Index()
        {
            ViewBag.LocalDateTime = DateTime.UtcNow.ToLocalDateTimeLongFormatString();
            ViewBag.HijriDateTime =   DateTime.UtcNow.ToLocalDateTime().ToHijriDateTime();
            return View();
        }
        //=============================================================================================
        public int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.ToList()[1].Value);
        }
        //==============================================================================================
        //==============================================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            // dashboardService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
