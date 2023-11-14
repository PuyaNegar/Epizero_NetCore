using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.BasicDefinitionsServices;
using PanelBusinessLogicLayer.BusinessServices.SystemsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelViewModels.BaseViewModels;
using PanelViewModels.BasicDefinitionsViewModels;

namespace PanelPresentationLayer.Areas.BasicDefinitions.Controllers
{
    [Area("BasicDefinitions")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class ProvincesController : Controller
    {
        private ProvincesServices provincesService;
        //===========================================================================
        public ProvincesController()
        {
            this.provincesService = new ProvincesServices();
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
                var sysResult = provincesService.Read();
                var result = sysResult.GetGridData<ProvincesViewModel>
                    (request);
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Create([FromBody] ProvincesViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = provincesService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = provincesService.Find(viewModel.Id.Value);
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody]  ProvincesViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = provincesService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = provincesService.Delete(viewModel);
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
            provincesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
