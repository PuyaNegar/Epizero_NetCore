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
    public class LiveOnlineClassesController : Controller
    { 
        private LiveOnlineClassesService liveOnlineClassesService;
        //======================================================
        public LiveOnlineClassesController()
        {
            liveOnlineClassesService = new  LiveOnlineClassesService(); 
        }
        //====================================================== 
        [HttpGet]
        [ApiService]
        public async Task<IActionResult> Read ( )
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = liveOnlineClassesService.Read(GetCurrentUserId());
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
            liveOnlineClassesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion 
    }
}
