using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.ContentsServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.ContentsViewModels;

namespace PanelPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class CourseNotificationsController : Controller
    {
        private CourseNotificationsService courseNotificationsService;
        //===========================================================================
        public CourseNotificationsController()
        {
            this.courseNotificationsService = new CourseNotificationsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var courseServcie = new CoursesService())
                {
                    ViewBag.Courses = courseServcie.ReadForComboBox().Value;
                }
                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = courseNotificationsService.Read();
                var result = sysResult.GetGridData<CourseNotificationsViewModel>
                    (request);
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseNotificationsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseNotificationsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseNotificationsService.Find(viewModel.Id.Value);
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CourseNotificationsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseNotificationsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseNotificationsService.Delete(viewModel);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> UpdateDescription([FromBody] NotificationsDescriptionViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = courseNotificationsService.UpdateDescription(viewModel.Id, viewModel.Description, GetCurrentUserId());
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
            courseNotificationsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
