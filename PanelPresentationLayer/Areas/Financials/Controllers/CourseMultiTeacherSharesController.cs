using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels; 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class CourseMultiTeacherSharesController : Controller
    {
        private CourseMultiTeacherSharesService courseMultiTeacherSharesService;

        public CourseMultiTeacherSharesController()
        {
            courseMultiTeacherSharesService = new CourseMultiTeacherSharesService(); 
        }
        //==========================================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var teacherUserService = new TeacherUsersService())
                {
                    ViewBag.Teachers = teacherUserService.ReadForComboBox().Value;
                }
                using (var CouresService = new CoursesService())
                {
                    var result = CouresService.Find(Id).Value;
                    ViewBag.CourseId = Id;
                    ViewBag.CourseName = result.Name;

                }
                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request , int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMultiTeacherSharesService.Read(Id).GetGridData<CourseMultiTeacherSharesViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseMultiTeacherSharesViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMultiTeacherSharesService.Add(viewModel, GetCurrentUserId() );
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMultiTeacherSharesService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CourseMultiTeacherSharesViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMultiTeacherSharesService.Update(viewModel, GetCurrentUserId() );
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMultiTeacherSharesService.Delete(viewModel);
                return Json(result);
            });
        }
        //=========================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            courseMultiTeacherSharesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
