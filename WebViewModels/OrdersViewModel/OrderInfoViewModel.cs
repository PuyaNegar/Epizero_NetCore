using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebViewModels.OrdersViewModel
{
    public class OrderInfoViewModel
    {
       
        //=========================================================
        /// <summary>
        /// مبلغ قابل پرداخت
        /// </summary>
        public int PaymentAmount { get; set; }
        //=========================================================
        /// <summary>
        /// تعداد کارت ها
        /// </summary>
        public int OrderDetailsCount { get; set; }
         
        //=========================================================
        /// <summary>
        /// لیست جزئیات کارت
        /// </summary>
        public List<OrderDetailsViewModel> OrderDetails { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public int? UserId { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public int  TotalPaymentAmount { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public int TotalDiscountCodeAmount { get; set;  } 
        //=========================================================
        /// <summary>
        /// جمع مبلغ سفارش
        /// </summary>
        public int SubTotal { get; set; }
        //=========================================================
        /// <summary>
        /// جمع مبلغ سفارش
        /// </summary>
        public int TotalPriceWithDiscount { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public bool  IsDiscountCodeApplied { get; set;  }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string DiscountCode { get; set;  }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public int? DiscountCodeId { get; set; }

    }

}
