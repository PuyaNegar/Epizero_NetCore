using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
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
    public class CourseMeetingsController : Controller
    {
        private CourseMeetingsService courseMeetingsService;
        //===========================================================================
        public CourseMeetingsController()
        {
            this.courseMeetingsService = new CourseMeetingsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var coursesService = new CoursesService())
                {
                    var courseModel = (CoursesViewModel)coursesService.Find(Id).Value;
                    ViewBag.CourseName = courseModel.Name;
                    ViewBag.IsMultiTeacher = (bool)courseModel.IsMultiTeacher.ToBoolean();
                }
                using (var teacherUsersService = new TeacherUsersService())
                {
                    ViewBag.Teachers = teacherUsersService.ReadForComboBox(UserGroup.Teacher).Value;
                }
                ViewBag.CourseId = Id;
                return View();
            });

        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request, int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingsService.Read(Id).GetGridData<CourseMeetingsViewModel>(request);
                return Json(result);
            });
        }
        //===========================================================================
        public async Task<IActionResult> ReadForComboBox(  int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingsService.ReadForComboBox(Id) ;
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseMeetingsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingsService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CourseMeetingsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingsService.Delete(viewModel);
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
            courseMeetingsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
