using Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TeacherTrainingsServices;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TeacherTrainingsViewModels;
using System;
using System.Threading.Tasks;
using TeacherPresentationLayer.Infrastracture.Filters;
using TeacherPresentationLayer.Infrastracture.Functions;

namespace TeacherPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class HomeworksController : Controller
    {
        private TeacherHomeworksService homeworksService;
        public HomeworksController()
        {
            homeworksService = new TeacherHomeworksService();
        }
        public async  Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var coursesService = new TeacherCoursesService())
                {
                    var result = coursesService.ReadWithCourseMeetings(GetCurrentUserId().Value, CourseCategoryType.Training).Value;
                    ViewBag.Courses = result;
                    return View();
                }
            });
        }
        //==================================================
        [HttpGet]
        [ApiService]
        public async Task<IActionResult> Read([FromQuery] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = homeworksService.Read(viewModel.Id.Value, GetCurrentUserId().Value);
                return Ok(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TeacherHomeworksViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = homeworksService.Add(viewModel, GetCurrentUserId().Value);
                return Json(result);
            });
        }
        //============================================================================
        [HttpGet]
        [ApiService]
        public async Task<IActionResult> Find(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = homeworksService.Find(Id, GetCurrentUserId().Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TeacherHomeworksViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = homeworksService.Update(viewModel, GetCurrentUserId().Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        [ApiService]
        public async Task<IActionResult> Delete([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = homeworksService.Delete(viewModel.Id.Value , GetCurrentUserId().Value);
                return Json(result);
            });
        }
        //==================================================
        public int? GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            // courseMeetingsStudentsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
