using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.ContentsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelViewModels.BaseViewModels;
using PanelViewModels.ContentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [Authorize] 
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class ProductPromoSectionsController : Controller
    {
        private ProductPromoSectionsService productPromoSectionGroupsService;
        //===========================================================================
        public ProductPromoSectionsController()
        {
            this.productPromoSectionGroupsService = new ProductPromoSectionsService();
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
                var sysResult = productPromoSectionGroupsService.Read();
                var result = sysResult.GetGridData<ProductPromoSectionsViewModel>
                    (request);
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Create([FromBody] ProductPromoSectionsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = productPromoSectionGroupsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = productPromoSectionGroupsService.Find(viewModel.Id.Value);
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody] ProductPromoSectionsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = productPromoSectionGroupsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = productPromoSectionGroupsService.Delete(viewModel);
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
            productPromoSectionGroupsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
