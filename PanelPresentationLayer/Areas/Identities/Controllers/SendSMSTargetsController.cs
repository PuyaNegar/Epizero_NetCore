using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelViewModels.BaseViewModels;
using PanelViewModels.IdentitiesViewModels;

namespace PanelPresentationLayer.Areas.Identities.Controllers
{
    [Area("Identities")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class SendSMSTargetsController : Controller
    {
        private SendSMSTargetsService sendSMSTargetsService;
        //===========================================================================
        public SendSMSTargetsController()
        {
            this.sendSMSTargetsService = new SendSMSTargetsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            });

        }
        //===========================================================================
        public async Task<JsonResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var sysResult = sendSMSTargetsService.Read();
                var result = sysResult.GetGridData<SendSMSTargetsViewModel>
                    (request);
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Create([FromBody] SendSMSTargetsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            { 
                var result = sendSMSTargetsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = sendSMSTargetsService.Find(viewModel.Id.Value);
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody] SendSMSTargetsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            { 
                var result = sendSMSTargetsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = sendSMSTargetsService.Delete(viewModel);
                return Json(result);
            });

        }
        //===========================================================================
        public int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.ToList()[1].Value);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            sendSMSTargetsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}