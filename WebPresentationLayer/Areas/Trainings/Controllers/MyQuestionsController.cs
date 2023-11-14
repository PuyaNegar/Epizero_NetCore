using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using WebBusinessLogicLayer.BusinessServices.TrainingsServices;
using WebViewModels.TrainingsViewModels;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;

namespace WebPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class MyQuestionsController : Controller
    {
        private CourseStudentQuestionsService courseStudentQuestionsService;
        public MyQuestionsController()
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
                var result = courseStudentQuestionsService.Read(Id, GetCurrentUserId(), true);
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
                var result = courseStudentQuestionsService.Read(Id, null, false);
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
