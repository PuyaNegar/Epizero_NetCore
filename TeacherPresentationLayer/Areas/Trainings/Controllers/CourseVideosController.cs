using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TeacherTrainingsServices;
using PanelViewModels.TeacherTrainingsViewModels;
using TeacherPresentationLayer.Infrastracture.Filters;
using TeacherPresentationLayer.Infrastracture.Functions;

namespace TeacherPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class CourseVideosController : Controller
    {
        private TeacherCourseVideosService courseVideosService;
        //==================================================
        public CourseVideosController()
        {
            courseVideosService = new TeacherCourseVideosService();
        }
        //==================================================
        public async Task<IActionResult> Index(int? Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var coursesService = new TeacherCoursesService())
                {
                    var result = coursesService.ReadWithCourseMeetings(GetCurrentUserId().Value ,  CourseCategoryType.Training).Value;
                    ViewBag.Courses = result;
                    if (Id == null && result.Any())
                    {
                        var courseId = result.First().Id;
                        ViewBag.Data = courseVideosService.Read(courseId, GetCurrentUserId().Value).Value;
                        ViewBag.CourseId = courseId;
                    }
                    else if (Id != null)
                    {
                        ViewBag.CourseId = Id.Value;
                        ViewBag.Data = courseVideosService.Read(Id.Value, GetCurrentUserId().Value).Value; 
                    }
                    else
                    {
                        ViewBag.Data = new List<TeacherCourseMeetingVideoGroupsViewModel>();
                    }
                    return View();
                }
            });
        } 
        //===========================================================================
        public int? GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            courseVideosService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
