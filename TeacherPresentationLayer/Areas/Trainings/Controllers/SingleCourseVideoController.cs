using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TeacherTrainingsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherPresentationLayer.Infrastracture.Filters;
using TeacherPresentationLayer.Infrastracture.Functions;

namespace TeacherPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class SingleCourseVideoController : Controller
    {
        private TeacherCourseVideosService courseVideosService;
        //==================================================
        public SingleCourseVideoController()
        {
            courseVideosService = new TeacherCourseVideosService();
        }


        //==================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var coursesService = new TeacherCoursesService())
                {
                    var result = courseVideosService.Find(Id, GetCurrentUserId().Value).Value;
                    ViewBag.VideoDetail = result;

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
