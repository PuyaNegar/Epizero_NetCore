using System;
using System.Threading.Tasks;
using Common.Objects;
using Microsoft.AspNetCore.Mvc; 
using WebBusinessLogicLayer.BusinessServices.ContentsServices;

namespace WebPresentationLayer.Controllers
{
    public class HomeController : Controller
    {

        private ContentsServices contentsServices;
        public HomeController()
        {
            contentsServices = new ContentsServices();
        }
        //=========================================================================
        public async Task<IActionResult> Index()
        { 
            return await Task.Run<IActionResult>(() =>
            {
                using (var d =new AboutUsService())
                {
                    ViewBag.About = d.Read().Value.MetaDescription;
                }
                ViewBag.Data = contentsServices.Read().Value;
                return View();
            });
        }
        //=================================================
        public IActionResult KeepAlive()
        {
            return Ok(new SysResult() { IsSuccess = true });
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            contentsServices?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
