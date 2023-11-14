using System;
using Microsoft.AspNetCore.Mvc;
using Common.Functions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace PanelPresentationLayer.Controllers
{
    public class CaptchaController : Controller
    {
        private Captcha captcha;
        IWebHostEnvironment env;
        public CaptchaController(IWebHostEnvironment  _webHostEnvironment)
        {
            var backgroundImagePath = _webHostEnvironment.ContentRootPath + @"\wwwroot\assets\images\captcha.png";
            captcha = new Captcha(backgroundImagePath);
            this.env = _webHostEnvironment;
        }
        //========================================================
        public IActionResult Get()
        {
                captcha.Build();
                HttpContext.Session.SetString("Captcha", captcha.GetGeneratedText());
                return File(captcha.GetGeneratedImage(), "image/gif");
        }
        //============================================================================================== Disposing 
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            captcha?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
        //==============================================================================================

    }
}