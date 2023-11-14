using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.OrdersViewModel
{
    public class OrderDetailsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //===========================================================
        /// <summary>
        /// نام آیتم
        /// </summary>
        public string AcademyProductName { get; set; }
        //===========================================================
        /// <summary>
        /// قیمت
        /// </summary>
        public int Price { get; set; }
        //===========================================================
        /// <summary>
        /// قیمت نهایی
        /// </summary>
        public int PriceWithDiscount { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public int AcademyProductId { get; set; }
        ////=========================================================== 
        ///  /// <summary>
        /// 
        /// </summary>
        public int AcademyProductTypeId { get; set; }
        //=========================================================== 
        /// <summary>
        /// 
        /// </summary>
        public float DiscountPercent { get; set; }
        //=========================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string TecherFullName { get; set; }
        //=========================================================== 
        /// <summary>
        /// 
        /// </summary>
        public int? CourseId { get; set; }
        //=========================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string AcademyProductPicPath {get;set; }
        //=========================================================== 
        /// <summary>
        /// 
        /// </summary>
        public int DiscountCodeAmount { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public int FinalPrice { get; set;  }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public int SalePartnerPrice { get; set;  }
    }
}
