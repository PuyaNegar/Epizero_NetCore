using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.OrdersViewModel;
using WebBusinessLogicLayer.BusinessServices.OrdersServices;

namespace WebPresentationLayer.Areas.Orders.Controllers
{ 
    [Area("Orders")] 
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class DiscountCodesController : Controller
    {
        private DiscountCodesService discountCodesService;
        //==============================================================
        public DiscountCodesController()
        {
            discountCodesService = new DiscountCodesService(); 
        } 
        //==============================================================
        [HttpPost]
        [ApiService]
        public async Task<IActionResult> AppendToOrder([FromBody] DiscountCodeViewModel request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                int orderId = GetOrderId();
               var result =  discountCodesService.AppendToOrder(request.Code, GetCurrentUserId(), orderId);
                return Ok(result);
            });
        } 
        //==============================================================
        [HttpPost]
        [ApiService]
        public async Task<IActionResult> DeleteFromOrder(  )
        {
            return await Task.Run<IActionResult>(() =>
            {
                int orderId = GetOrderId();
                var result = discountCodesService.DeleteFromOrder(orderId);
                return Ok( result );
            });
        } 
        //============================================================== 
        public int? GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        } 
        //===========================================================================
        int GetOrderId()
        {
            return CurrentContext.GetOrderId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            discountCodesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
