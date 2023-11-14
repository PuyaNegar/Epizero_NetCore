using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.IdentitiesViewModels;

namespace WebPresentationLayer.Areas.Identities.Controllers
{
    [Area("Identities")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class StudentUserSmsController : Controller
    {
        private StudentUserSmsService studentUserSmsService;
        //===========================================
        public StudentUserSmsController()
        {
            studentUserSmsService = new StudentUserSmsService();
        }
        //===========================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.StudentUserSms = studentUserSmsService.Read(GetCurrentUserId()).Value;
                return View();
            });
        }
        //===========================================
        [HttpPost]
        [ApiService]
        public async Task<IActionResult> Add([FromBody] List<int> smsOptionId)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentUserSmsService.Add(smsOptionId, GetCurrentUserId());
                return Ok(result);
            });
        }
        //===========================================
        [HttpPost]
        [ApiService]
        public async Task<IActionResult> IncreaseCredit([FromBody] IncreaseSmsCreditViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentUserSmsService.IncreaseCredit(GetCurrentUserId(), viewModel.Amount);
                return Ok(result);
            });
        }
        //===========================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentUserSmsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
