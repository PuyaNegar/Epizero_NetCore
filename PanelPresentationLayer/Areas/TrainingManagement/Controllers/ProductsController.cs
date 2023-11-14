using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{

    [Area("TrainingManagement")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class ProductsController : Controller
    {
        private ProductsService productsService;
        //===========================================================================
        public ProductsController()
        {
            this.productsService = new ProductsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var productTypeService = new ProductTypesService())
                {
                    ViewBag.ProductTypes = productTypeService.ReadForComboBox().Value;
                }
                return View();
            });
        }
        //===========================================================================
        public async Task<JsonResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var sysResult = productsService.Read();
                var result = sysResult.GetGridData<ProductsViewModel>(request);
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Add([FromBody] ProductsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = productsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = productsService.Find(viewModel.Id.Value);
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody] ProductsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = productsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = productsService.Delete(viewModel);
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> UpdateDescription([FromBody] CourseDescriptionViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = productsService.UpdateDescription(viewModel.Id, viewModel.Description, GetCurrentUserId());
                return Json(result);
            });
        }
        //==========================================================================
        public int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.ToList()[1].Value);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            productsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
