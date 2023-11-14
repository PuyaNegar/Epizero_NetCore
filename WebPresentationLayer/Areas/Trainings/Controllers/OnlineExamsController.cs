using Common.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using WebBusinessLogicLayer.BusinessServices.TrainingsServices;
using WebPresentationLayer.Infrastracture.Filters;

namespace WebPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class OnlineExamsController : Controller
    {
        private CoursesService courseService;
        //========================================================================= 
        public OnlineExamsController()
        {
            courseService = new CoursesService();
        }
        //=========================================================================
        public IActionResult Index()
        {
            ViewBag.Data = courseService.ReadByCourseCategoryType(CourseCategoryType.OnlineExam).Value;
            return View();
        }
        //========================================================================= Disposing

        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            courseService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion 
    }
}
