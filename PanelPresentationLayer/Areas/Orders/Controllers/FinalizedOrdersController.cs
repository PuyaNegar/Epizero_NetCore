using System; 
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.OrdersServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.OrderViewModels;

namespace PanelPresentationLayer.Areas.Orders.Controllers
{
    [Area("Orders")]
    [Authorize]
    [AdminPermision]
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
                var sysResult = finalizedOrdersService.Read();
                var result = sysResult.GetGridData<FinalizedOrderReadViewModel>(request);
                return Json(result);
            });

        } 
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] FinalizedOrdersViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = finalizedOrdersService.Find(viewModel.Id);
                return Json(result);
            });
        }
        //===========================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
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
