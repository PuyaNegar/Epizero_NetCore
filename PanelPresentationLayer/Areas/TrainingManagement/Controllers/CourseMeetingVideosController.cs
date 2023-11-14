using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
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
    public class CourseMeetingVideosController : Controller
    {
        private CourseMeetingVideosService courseMeetingVideosService;
        //===========================================================================
        public CourseMeetingVideosController()
        {
            this.courseMeetingVideosService = new CourseMeetingVideosService();
        }
        //===========================================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var courseMeetingService = new CourseMeetingsService())
                {
                    var result = courseMeetingService.Find(Id).Value;
                    ViewBag.CourseMeetingName = result.Name;
                    ViewBag.CourseMeetingId = Id;
                }

                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request, int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = courseMeetingVideosService.Read(Id);
                var result = sysResult.GetGridData<CourseMeetingVideosViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseMeetingVideosViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingVideosService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingVideosService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CourseMeetingVideosViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingVideosService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingVideosService.Delete(viewModel);
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
            courseMeetingVideosService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
