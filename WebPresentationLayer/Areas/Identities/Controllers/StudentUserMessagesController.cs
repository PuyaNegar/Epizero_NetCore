using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.IdentitiesViewModels;

namespace WebPresentationLayer.Areas.Identities.Controllers
{
    [Area("Identities")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class StudentUserMessagesController : Controller
    {
        private StudentUserMessagesService studentUserMessagesService;
        //===========================================================================
        public StudentUserMessagesController()
        {
            studentUserMessagesService = new StudentUserMessagesService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            });
        }
        //======================================================================================
        [ApiService]
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentUserMessagesService.Read(GetCurrentUserId().Value);
                return Json(result);
            });
        }
        //=============================================================================
        [ApiService]
        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody] StudentUserMessagesViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentUserMessagesService.Add(viewModel, GetCurrentUserId().Value);
                return Ok(result);
            });
        }
        //======================================================================================
        public int? GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentUserMessagesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
