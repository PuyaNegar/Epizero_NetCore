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
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class CourseBookletsController : Controller
    {
        private CourseBookletsService courseBookletsService;
        //===========================================================================
        public CourseBookletsController()
        {
            this.courseBookletsService = new CourseBookletsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var courseService = new CoursesService())
                {
                    var result = courseService.Find(Id).Value;
                    ViewBag.CourseName = result.Name;
                    ViewBag.CourseId = Id;
                }

                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request, int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = courseBookletsService.Read(Id);
                var result = sysResult.GetGridData<CourseBookletsViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseBookletsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseBookletsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseBookletsService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CourseBookletsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseBookletsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseBookletsService.Delete(viewModel);
                return Json(result);
            });
        }
        //===========================================================================
        //[HttpPost]
        //public async Task<JsonResult> UpdateDescription([FromBody] CourseDescriptionViewModel viewModel)
        //{
        //    return await Task.Run<JsonResult>(() =>
        //    {
        //        var result = courseMeetingBookletsService.UpdateDescription(viewModel.Id, viewModel.Description, GetCurrentUserId());
        //        return Json(result);
        //    });
        //}

        //===========================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            courseBookletsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
