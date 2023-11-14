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
    public class HomeworkAnswersController : Controller
    {
        private TeacherHomeworkAnswersService homeworkAnswersService;
        public HomeworkAnswersController()
        {
            homeworkAnswersService = new TeacherHomeworkAnswersService();
        }
        //==================================================
        public async Task<IActionResult> Index()
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
                var result = homeworkAnswersService.Read(viewModel.Id.Value, GetCurrentUserId().Value);
                return Ok(result);
            });
        }
        //==================================================
        [HttpPost]
        public async Task<IActionResult> UpdateGrade([FromBody] TeacherHomeworkAnswerGradesViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = homeworkAnswersService.UpdateGrade(viewModel, GetCurrentUserId().Value);
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
