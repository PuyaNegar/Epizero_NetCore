using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TeacherFinancialsServices;
using PanelBusinessLogicLayer.BusinessServices.TeacherTrainingsServices;
using PanelViewModels.BaseViewModels;
using System;
using System.Threading.Tasks;
using TeacherPresentationLayer.Infrastracture.Filters;
using TeacherPresentationLayer.Infrastracture.Functions;

namespace TeacherPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class CourseStudentFinancialsController : Controller
    {
        private TeacherCourseStudentFinancialsService courseStudentFinancialsService;
        private TeacherSattlementsService teacherSattlementsService;
        //==================================================
        public CourseStudentFinancialsController()
        {
            courseStudentFinancialsService = new  TeacherCourseStudentFinancialsService();
            teacherSattlementsService = new TeacherSattlementsService();
        } 
        //==================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {

                if (!teacherSattlementsService.IsShow(GetCurrentUserId().Value).Value)
                    return NotFound();
                else
                {
                    using (var coursesService = new TeacherCoursesService())
                    {
                        var result = coursesService.ReadWithCourseMeetings(GetCurrentUserId().Value, null).Value;
                        ViewBag.Courses = result;
                        return View();
                    }
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
                var result = courseStudentFinancialsService.Read(viewModel.Id.Value , GetCurrentUserId().Value );
                return Ok(result);
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
            courseStudentFinancialsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
