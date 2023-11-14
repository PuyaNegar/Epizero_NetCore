using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.OrderViewModels
{
    public class FinalizedOrdersViewModel
    {
        //==========================================================
        /// <summary>
        /// هزینه ارسال
        /// </summary>
        [Display(Name = "شناسه سفارش")]
        public int Id { get; set; }
        //==========================================================
        /// <summary>
        /// شماره سفارش
        /// </summary>
        [Display(Name = "شماره سفارش")]
        public string InvoiceNo { get; set; }
        //==========================================================
        /// <summary>
        /// جزئیات سفارش
        /// </summary>
        [Display(Name = "جزئیات سفارش")]
        public List<FinalizedOrderDetailsViewModel> OrderDetails { get; set; }
        //==========================================================
        /// <summary>
        /// مبلغ قابل پرداخت
        /// </summary>
        [Display(Name = "مبلغ پرداخت‌ شده")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int PaymentAmount { get; set; }
        //==========================================================
        /// <summary>
        /// نام مشتری
        /// </summary>
        [Display(Name = "نام مشتری")]
        public string StudentUserFullName { get; set; }

        //========================================================== 
        /// <summary>
        /// تاریخ و زمان ثبت
        /// </summary>
        [Display(Name = "تاریخ و زمان ثبت")]
        public string OrderRegDateTime { get; set; }

        //========================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary> 
        [Display(Name = "مبلغ کد تخفیف")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int TotalDiscountCodeAmount { get; set; }
        //==========================================================
        /// <summary>
        /// جمع قیمت محصولات (تومان)
        /// </summary>
        [Display(Name = "مبلغ کل فاکتور(بدون احتساب تخفیف)")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int SubTotal { get; set; }
        //=========================================================
        /// <summary>
        /// جمع مبلغ سفارش
        /// </summary>
        [Display(Name = "مبلغ کل فاکتور (بااحتساب تخفیف)")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int TotalPriceWithDiscount { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "کد تخفیف")]
        public string DiscountCode { get; set; }
    }
}
