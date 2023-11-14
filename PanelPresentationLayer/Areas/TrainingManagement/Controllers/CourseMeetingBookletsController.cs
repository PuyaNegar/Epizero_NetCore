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
    public class CourseMeetingBookletsController : Controller
    {
        private CourseMeetingBookletsService courseMeetingBookletsService;
        //===========================================================================
        public CourseMeetingBookletsController()
        {
            this.courseMeetingBookletsService = new CourseMeetingBookletsService();
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
        public async Task<IActionResult> Read([FromForm] DataTableRequest request , int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = courseMeetingBookletsService.Read(Id);
                var result = sysResult.GetGridData<CourseMeetingBookletsViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseMeetingBookletsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingBookletsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingBookletsService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CourseMeetingBookletsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingBookletsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingBookletsService.Delete(viewModel);
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
            courseMeetingBookletsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
