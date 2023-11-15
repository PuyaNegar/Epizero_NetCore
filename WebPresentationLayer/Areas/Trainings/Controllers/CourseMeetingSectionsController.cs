using System;
using System.Threading.Tasks;
using Common.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBusinessLogicLayer.BusinessServices.TrainingsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;

namespace WebPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class CourseMeetingSectionsController : Controller
    {
        private CourseMeetingSectionsService studentHomeworksService;
        //=========================================================================
        public CourseMeetingSectionsController()
        {
            studentHomeworksService = new CourseMeetingSectionsService();
        }
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                int courseMeetingId = Request.Query["CourseMeetingId"].ToString().ToIntegerIdentifier();
                ViewBag.CourseMeetingId = courseMeetingId;
                ViewBag.Data = studentHomeworksService.Read(GetCurrentUserId() , courseMeetingId).Value;
                return View();
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
           // studentBookletsService?.Dispose();
            //GC.SuppressFinalize(this);
        }
        #endregion 
    }
}
