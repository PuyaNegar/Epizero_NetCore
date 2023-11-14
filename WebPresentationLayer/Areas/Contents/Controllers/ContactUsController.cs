using Common.Functions;
using Common.Objects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.ContentsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebViewModels.ContentsViewModels;

namespace WebPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class ContactUsController : Controller
    {
        private ContactUsService contactUsService;
        //===========================================================================
        public ContactUsController()
        {
            contactUsService = new ContactUsService();
        }
        //===========================================================================
        public async Task< IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            }); 
        }
        //===========================================================================
        [ApiService]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ContactUsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                if (HttpContext.Session.GetString("Captcha") != null)
                {
                    if (HttpContext.Session.GetString("Captcha") != viewModel.CaptchText.Trim().ToLower())
                    {
                        throw new CustomException("متن عکس صحیح نمی باشد");
                    }
                }
                var result = contactUsService.Add(viewModel);
                return Ok(result);
            });
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            contactUsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
