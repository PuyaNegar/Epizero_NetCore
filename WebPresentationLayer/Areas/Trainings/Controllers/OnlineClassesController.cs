using Common.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System; 
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.TrainingsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.BaseViewModels;

namespace WebPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class OnlineClassesController : Controller
    { 
        private OnlineClassesService onlineClassesService;
        //======================================================
        public OnlineClassesController()
        {
            onlineClassesService = new OnlineClassesService(); 
        }
        //======================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.onlineClasses = onlineClassesService.Read(GetCurrentUserId()).Value;
                return View();
            });
        } 
        //==================================================================
        [HttpPost]
        public async Task<IActionResult> JoinToClass()
        {
            return await Task.Run<IActionResult>(() =>
            {
                int courseId = Request.Query["CourseMeetingId"].ToString().ToIntegerIdentifier();
                var result = onlineClassesService.JoinToClass(GetCurrentUserId(), courseId);
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
            onlineClassesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion 
    }
}
