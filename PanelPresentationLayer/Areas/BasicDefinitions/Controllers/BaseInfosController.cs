using System;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BasicDefinitionsViewModels;
using PanelBusinessLogicLayer.BusinessServices.BasicDefinitionsServices;

namespace PanelPresentationLayer.Areas.BasicDefinitions.Controllers
{
    [Area("BasicDefinitions")]
    [Authorize] 
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class BaseInfosController : Controller, IDisposable
    {
        private BaseInfosService baseInfosService;
        //===========================================================================
        public BaseInfosController()
        {
            this.baseInfosService = new BaseInfosService();
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
                var sysResult = baseInfosService.Read();
                var result = sysResult.GetGridData<BaseInfosViewModel>(request);
                return Json(result);
            }); 
        } 
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find()
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = baseInfosService.Find();
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody]  BaseInfosViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = baseInfosService.Update(viewModel, CurrentContext.GetCurrentUserId(this));
                return Json(result);
            });

        }  

        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            baseInfosService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
