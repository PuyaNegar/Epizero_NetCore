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
    public class CourseSampleVideosController : Controller
    {
        private CourseSampleVideosService courseSampleVideosService;
        //===========================================================================
        public CourseSampleVideosController()
        {
            this.courseSampleVideosService = new CourseSampleVideosService();
        }
        //===========================================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.CourseId = Id;
                using (var coursesService = new CoursesService())
                {
                    var result = coursesService.Find(Id).Value;
                    ViewBag.CourseName = result.Name;
                }
                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request, int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = courseSampleVideosService.Read(Id);
                var result = sysResult.GetGridData<CourseSampleVideosViewModel>
                (request);
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseSampleVideosViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseSampleVideosService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseSampleVideosService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CourseSampleVideosViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseSampleVideosService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseSampleVideosService.Delete(viewModel);
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
            courseSampleVideosService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
