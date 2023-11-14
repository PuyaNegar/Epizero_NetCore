using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TeacherTrainingsServices;
using System; 
using System.Threading.Tasks;
using TeacherPresentationLayer.Infrastracture.Filters;
using TeacherPresentationLayer.Infrastracture.Functions;

namespace WebPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class TeacherWeekSchedulesController : Controller
    { 
        private TeacherWeekSchedulesService weekSchedulesService;
        //=================================================================
        public TeacherWeekSchedulesController()
        {
            weekSchedulesService = new  TeacherWeekSchedulesService(); 
        }
        //=================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.TeacherWeekSchedules =  weekSchedulesService.Read(GetCurrentUserId()).Value;
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
