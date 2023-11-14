using Newtonsoft.Json; 
using System.ComponentModel.DataAnnotations;
using WebViewModels.UtilityJsonConvertor;

namespace WebViewModels.FinancialsViewModels
{
    public class FinalizedOrderDetailsViewModel
    {
        /// <summary>
        /// شناسه 
        /// </summary>
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        //=================================================
        /// <summary>
        /// نام
        /// </summary>
        //[Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [Display(Name = "نام")]
        public string AcademyProductName { get; set; }
        //=================================================
        /// <summary>
        /// قیمت
        /// </summary>
        //[Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [Display(Name = "قیمت")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int Price { get; set; }
        //================================================= 
        /// <summary>
        /// 
        /// </summary>
        public float DiscountPercent { get; set; } 
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int FinalPrice { get; set; } 
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int PriceWithDiscount { get; set; }
        //====================================================== 
        /// <summary>
        ///  
        /// </summary>
        public string AcademyProductTypeName { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int DiscountCodeAmount { get; set; }
        //======================================================
    }
}
