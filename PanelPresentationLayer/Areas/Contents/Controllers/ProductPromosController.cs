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
    public class ProductPromosController : Controller
    {
        private ProductPromosService productPromosService;
        //===========================================================================
        public ProductPromosController()
        {
            this.productPromosService = new ProductPromosService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var ProductPromoSectionGroupsService = new ProductPromoSectionsService())
                {
                    ViewBag.promoSections = ProductPromoSectionGroupsService.ReadForComboBox().Value;
                }
                //using (var groupsService = new GroupsService())
                //{
                //    ViewBag.Groups = groupsService.ReadForComboBox().Value;
                //}
                return View();
            });

        }
        //===========================================================================
        public async Task<JsonResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<JsonResult>(() =>
            {
                dynamic filter = request.Filters.ToFilterExpression();
                int PromoSectionsId = filter.PromoSectionsId == null ? 0 : filter.PromoSectionsId;
                var sysResult = productPromosService.ReadByPromoSection(PromoSectionsId);
                var result = sysResult.GetGridData<ProductPromosViewModel>
                    (request);
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Create([FromBody] ProductPromosViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = productPromosService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = productPromosService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody] ProductPromosViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = productPromosService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = productPromosService.Delete(viewModel);
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
            productPromosService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
