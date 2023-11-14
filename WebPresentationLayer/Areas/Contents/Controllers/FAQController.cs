using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.ContentsServices;
using WebPresentationLayer.Infrastracture.Filters;

namespace WebPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class FAQController : Controller
    {
      private  FAQService fAQService;
        //=========================================
        public FAQController()
        {
            fAQService = new FAQService();
        }
        //==========================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.Data = fAQService.Read().Value;
                return View();
            });
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            fAQService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
