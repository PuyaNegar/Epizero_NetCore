using System;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBusinessLogicLayer.BusinessServices.FinancialsServices;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebBusinessLogicLayer.BusinessServices.OrdersServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.FinancialsViewModels;
using WebViewModels.IdentitiesViewModels;
using WebViewModels.OrdersViewModel;

namespace WebPresentationLayer.Areas.Orders.Controllers
{
    [Area("Orders")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class OrdersController : Controller
    {
        private OrdersService orderService;
        //=============================================================
        public OrdersController()
        {
            orderService = new OrdersService();
        }
        //=============================================================
        public IActionResult Index()
        {
            var orderTask = GetOrder();
            var balanceTask = GetBalance();
            var scoreBalance = GetScoreBalance();
            Task.WaitAll(orderTask, balanceTask, scoreBalance);
            ViewBag.Data = orderTask.Result;
            ViewBag.Balance = balanceTask.Result.Balance;
            ViewBag.ScoreBalance = scoreBalance.Result.Balance;
            return View();
        }
        //=============================================================
        [HttpPost]
        [ApiService]
        public IActionResult AddItem([FromBody] AddOrderRequestViewModel request)
        {
            int CartId = GetOrderId();
            var result = orderService.AddItem(request, ref CartId, GetCurrentUserId());
            SetCartCookie(CartId);
            return Ok(result);
        }
        //==============================================================
        [HttpPost]
        [ApiService]
        public IActionResult RemoveItem([FromBody] RemoveOrderRequestViewModel request)
        {
            request.OrderId = GetOrderId();
            var result = orderService.RemoveItem(request, GetCurrentUserId());
            return Ok(result);
        }
        //==============================================================
        [HttpGet]
        [ApiService]
        public IActionResult CountOrderDetailItems()
        {
            var result = orderService.CountOrderDetailItems(GetOrderId());
            return Ok(result);
        }
        //==============================================================
        [HttpPost]
        [ApiService]
        public async Task<IActionResult> Delete()
        {
            return await Task.Run<IActionResult>(() =>
            {
                RemoveCartCookie();
                return Ok(new SysResult() { IsSuccess = true, Message = "سبد خرید با موفقیت حذف گردید" });
            });
        }
        //==============================================================
        Task<BalanceViewModel> GetBalance()
        {
            var task = new Task<BalanceViewModel>(() =>
            {
                if (User.Identity.IsAuthenticated)
                    using (var customerFinincesService = new StudentUserFinincesService())
                    {
                        return customerFinincesService.GetBalance(GetCurrentUserId().Value).Value;
                    }
                else
                    return new BalanceViewModel() { Balance = 0 };
            });
            task.Start();
            return task;
        }
        //===========================================================================
        Task<ScoreBalanceViewModel> GetScoreBalance()
        {
            var task = new Task<ScoreBalanceViewModel>(() =>
            {
                if (User.Identity.IsAuthenticated)
                    using (var studentUserScoresService = new StudentUserScoresService())
                    {
                        return studentUserScoresService.GetBalance(GetCurrentUserId().Value).Value;
                    }
                else
                    return new ScoreBalanceViewModel() { Balance = 0 };
            });
            task.Start();
            return task;
        }
        //===========================================================================
        Task<OrdersViewModel> GetOrder()
        {
            var task = new Task<OrdersViewModel>(() =>
            {
                using (var orderService = new OrdersService())
                {
                    return orderService.Read(GetOrderId(), GetCurrentUserId()).Value;
                }
            });
            task.Start();
            return task;
        }
        //===========================================================================
        int GetOrderId()
        {
            return CurrentContext.GetOrderId(this);
        }
        //===========================================================================
        void SetCartCookie(int? CartId)
        {
            var options = new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddHours(6)
            };
            Response.Cookies.Append("OrderHashId", CartId.ToString().EncriptWithDESAlgoritm(), options);
        }
        //===========================================================================
        void RemoveCartCookie()
        {
            Response.Cookies.Delete("OrderHashId");
        }
        //===========================================================================
        public int? GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            orderService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}