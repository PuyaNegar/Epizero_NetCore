using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.TrainingsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;

namespace WebPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class CourseNotificationsController : Controller
    {
        private CourseNotificationsService courseNotificationsService;
        //=============================================
        public CourseNotificationsController()
        {
            courseNotificationsService = new CourseNotificationsService( ); 
        }
        //=============================================
        [ApiService]
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseNotificationsService.Read(  CurrentContext.GetCurrentUserId(this).Value);
                return Json(result);
            });
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            courseNotificationsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
