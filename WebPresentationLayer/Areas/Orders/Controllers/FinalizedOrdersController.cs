using System; 
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBusinessLogicLayer.BusinessServices.OrdersServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.FinancialsViewModels;

namespace WebPresentationLayer.Areas.Orders.Controllers
{
    [Area("Orders")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class FinalizedOrdersController : Controller
    {
        private FinalizedOrdersService finalizedOrdersService;
        //===========================================================================
        public FinalizedOrdersController()
        {
            this.finalizedOrdersService = new FinalizedOrdersService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            });
        }
        //===========================================================================
        public async Task<JsonResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = finalizedOrdersService.Read(GetCurrentUserId());
                return Json(result);
            });

        } 
        //============================================================================
        [HttpGet]
        [ApiService]
        public async Task<JsonResult> Find(int Id)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = finalizedOrdersService.Find(Id , GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            finalizedOrdersService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
