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
    public class CoursePromosController : Controller
    {
        private CoursePromosService coursePromoSectionsService;
        //===========================================================================
        public CoursePromosController()
        {
            this.coursePromoSectionsService = new CoursePromosService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var coursePromoSectionGroupsService = new CoursePromoSectionsService())
                {
                    ViewBag.promoSections = coursePromoSectionGroupsService.ReadForComboBox().Value;
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
                var sysResult = coursePromoSectionsService.ReadByPromoSection(PromoSectionsId);
                var result = sysResult.GetGridData<CoursePromosViewModel>
                    (request);
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Create([FromBody] CoursePromosViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = coursePromoSectionsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = coursePromoSectionsService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody] CoursePromosViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = coursePromoSectionsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = coursePromoSectionsService.Delete(viewModel);
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
            coursePromoSectionsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
