using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelPresentationLayer.Infrastracture.Filters;
using System.Threading.Tasks;
using System;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using Common.Extentions;
using PanelViewModels.TrainingManagementViewModels;
using PanelViewModels.BaseViewModels;
using PanelPresentationLayer.Infrastracture.Functions;
using BusinessLogicLayer.BusinessServices.TrainingManagementServices;
using System.Collections.Generic;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class CourseStudentNewCommentsController : Controller
    {
        private CourseStudentNewCommentsService courseStudentNewCommentsService;
        //===========================================================================
        public CourseStudentNewCommentsController()
        {
            this.courseStudentNewCommentsService = new CourseStudentNewCommentsService();
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
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = courseStudentNewCommentsService.Read();
                var result = sysResult.GetGridData<CourseStudentNewCommentsViewModel>
                    (request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentNewCommentsService.Find(viewModel.Id.Value);
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CourseStudentNewCommentsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentNewCommentsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        [AdminPermision]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentNewCommentsService.Delete(viewModel);
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
            courseStudentNewCommentsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
