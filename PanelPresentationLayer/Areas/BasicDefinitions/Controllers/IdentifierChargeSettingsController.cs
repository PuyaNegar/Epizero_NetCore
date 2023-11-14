using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.BasicDefinitionsServices; 
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.IdentitiesViewModels;
using System;  
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.BasicDefinitions.Controllers
{
    [Area("BasicDefinitions")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class IdentifierChargeSettingsController : Controller, IDisposable
    {
        private IdentifierChargeSettingsService identifierChargeSettingsService;
        //===========================================================================
        public IdentifierChargeSettingsController()
        {
            this.identifierChargeSettingsService = new  IdentifierChargeSettingsService();
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
                var sysResult = identifierChargeSettingsService.Read();
                var result = sysResult.GetGridData<IdentifierChargeSettingsViewModel>(request);
                return Json(result);
            }); 
        }

        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find()
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = identifierChargeSettingsService.Find();
                return Json(result);
            }); 
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody] IdentifierChargeSettingsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = identifierChargeSettingsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            }); 
        }
        //===========================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this); 
        } 
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            identifierChargeSettingsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
