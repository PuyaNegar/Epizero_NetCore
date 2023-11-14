using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.ContentsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
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
    [AdminPermision]
    [ModelValidatorAsync] 
    [ExceptionHandlerAsync]
    public class OnlineExamPromosController : Controller
    {
        private OnlineExamPromosService OnlineExamPromoSectionsService;
        //===========================================================================
        public OnlineExamPromosController()
        {
            this.OnlineExamPromoSectionsService = new OnlineExamPromosService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var OnlineExamPromoSectionGroupsService = new OnlineExamPromoSectionsService())
                {
                    ViewBag.PromoSections = OnlineExamPromoSectionGroupsService.ReadForComboBox().Value;
                }
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
                var sysResult = OnlineExamPromoSectionsService.ReadByPromoSection(PromoSectionsId);
                var result = sysResult.GetGridData<OnlineExamPromosViewModel>
                    (request);
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Create([FromBody] OnlineExamPromosViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = OnlineExamPromoSectionsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = OnlineExamPromoSectionsService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody] OnlineExamPromosViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = OnlineExamPromoSectionsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = OnlineExamPromoSectionsService.Delete(viewModel);
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
            OnlineExamPromoSectionsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
