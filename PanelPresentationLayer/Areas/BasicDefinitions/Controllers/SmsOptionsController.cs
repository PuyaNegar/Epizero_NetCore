using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.BasicDefinitionsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelViewModels.BaseViewModels;
using PanelViewModels.BasicDefinitionsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.BasicDefinitions.Controllers
{
    [Area("BasicDefinitions")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class SmsOptionsController : Controller
    {
        private SmsOptionsService sMSOptionsService;
        //===========================================================================
        public SmsOptionsController()
        {
            this.sMSOptionsService = new SmsOptionsService();
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
                var sysResult = sMSOptionsService.Read();
                var result = sysResult.GetGridData<SmsOptionsViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = sMSOptionsService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody] SmsOptionsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = sMSOptionsService.Update(viewModel, GetCurrentUserId());
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
            sMSOptionsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
