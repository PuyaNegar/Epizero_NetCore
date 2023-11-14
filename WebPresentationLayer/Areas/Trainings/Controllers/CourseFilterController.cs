using Microsoft.AspNetCore.Mvc; 
using System;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using WebBusinessLogicLayer.BusinessServices.TrainingsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.TrainingsViewModels;

namespace WebPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class CourseFilterController : Controller
    {
        private CourseFilterService courseFilterService;
        //========================================================================= 
        public CourseFilterController()
        {
            courseFilterService = new CourseFilterService();
        }
        //========================================================================= 
        public async Task<IActionResult> Index([FromQuery] CourseFilterRequestViewModel request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var levelGroupsService = new LevelGroupsService())
                {
                    ViewBag.LevelDescription = levelGroupsService.Find(request.LevelGroupId).Value.Description;
                }
                ViewBag.Data =  courseFilterService.Read(request.LevelGroupId).Value;
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
            courseFilterService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion 
    }
}
