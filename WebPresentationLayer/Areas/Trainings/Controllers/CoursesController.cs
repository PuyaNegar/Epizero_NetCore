using Common.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.TrainingsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
namespace WebPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]

    public class CoursesController : Controller
    {
        private CoursesService coursesService;
        //=========================================================================
        public CoursesController()
        {
            coursesService = new CoursesService();
        }
        //=========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                 
                ViewBag.IsQuestionShow = string.IsNullOrEmpty(Request.Query["IsQuestion"]) ? false : true;
                ViewBag.UserId = GetCurrentUserId();
                int coursesId = Request.Query["CoursesId"].ToString().ToIntegerIdentifier();
                ViewBag.CoursesId = coursesId;
                ViewBag.Courses = coursesService.Read(coursesId, GetCurrentUserId()).Value;
                return View();
            });
        }
        //========================================================================= 
        public int? GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //========================================================================= Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            coursesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
