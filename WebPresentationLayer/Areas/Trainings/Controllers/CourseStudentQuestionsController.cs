using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.TrainingsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.TrainingsViewModels;

namespace WebPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class CourseStudentQuestionsController : Controller
    {
        private CourseStudentQuestionsService courseStudentQuestionsService;
        public CourseStudentQuestionsController()
        {
            courseStudentQuestionsService = new CourseStudentQuestionsService();
        }
        //========================================================================= 
        [Authorize]
        public IActionResult Index()
        {
            using (var studentCoursesService = new StudentCoursesService())
            {
                ViewBag.studentCourses = studentCoursesService.Read(GetCurrentUserId()).Value;
            }
            return View();
        }
        //=========================================================================
        [Authorize]
        [ApiService]
        [HttpGet]
        public async Task<IActionResult> Read(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentQuestionsService.Read(Id, null , true);
                return Json(result);
            });
        }
        //=========================================================================
        [ApiService]
        [HttpGet]
        public async Task<IActionResult> ReadAll(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentQuestionsService.Read(Id, null , false);
                return Json(result);
            });
        }
        //========================================================================= 
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddQuestion([FromBody] AddCourseStudentQuestionsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentQuestionsService.Add(viewModel, GetCurrentUserId());
                return Ok(result);
            });

        }
        //========================================================================= 
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAnswer([FromBody] AddCourseStudentQuestionAnswersViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentQuestionsService.AddAnswer(viewModel, GetCurrentUserId());
                return Ok(result);
            });

        }
        //========================================================================= 
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
        //========================================================================= Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            courseStudentQuestionsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion 
    }
}
