using System; 
using System.Threading.Tasks;
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
    public class CourseMeetingBookletsController : Controller
    {
        private StudentBookletsService studentBookletsService;
        //========================================================================= 
        public CourseMeetingBookletsController()
        {
            studentBookletsService = new StudentBookletsService(); 
        }
        //========================================================================= 
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.Data = studentBookletsService.Read(GetCurrentUserId()).Value; 
                return View();
            });
        } 
        //========================================================================= 
        public int  GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
        //========================================================================= Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentBookletsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion 
    }
}
