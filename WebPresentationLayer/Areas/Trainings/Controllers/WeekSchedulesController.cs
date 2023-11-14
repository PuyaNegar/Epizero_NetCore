using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class WeekSchedulesController : Controller
    { 
        private WeekSchedulesService weekSchedulesService;
        //=================================================================
        public WeekSchedulesController()
        {
            weekSchedulesService = new WeekSchedulesService(); 
        }
        //=================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.Data =  weekSchedulesService.Read(GetCurrentUserId()).Value;
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
            weekSchedulesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion 
    }
}
