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
    public class HomeworksController : Controller
    {
        private HomeworksService homeworksService;
        //===========================================================================
        public HomeworksController()
        {
            this.homeworksService = new HomeworksService();
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
                var sysResult = homeworksService.Read(Id);
                var result = sysResult.GetGridData<HomeworksViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] HomeworksViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = homeworksService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = homeworksService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] HomeworksViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = homeworksService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = homeworksService.Delete(viewModel);
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
            homeworksService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
