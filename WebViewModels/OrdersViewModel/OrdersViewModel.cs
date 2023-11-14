using Common.Enums;
using Newtonsoft.Json;

namespace WebViewModels.OrdersViewModel
{
    public class OrdersViewModel
    {
        //=========================================================
        /// <summary>
        /// شناسه  کارت
        /// </summary>
        [JsonIgnore]
        public int OrderId { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public int?  DiscountCodeId { get; set;  }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public int ? Score { get; set; }
        //=========================================================
        /// <summary>
        /// شناسه  کارت
        /// </summary>
        public string HashOrderId { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsEmptyOrder { get; set; }
        //=========================================================
        /// <summary>
        /// وضعیت کارت
        /// </summary>
        public OrderStatusType OrderStatusTypes { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public OrderInfoViewModel OrderInfo { get; set; }
        //==========================================================
    }
}
