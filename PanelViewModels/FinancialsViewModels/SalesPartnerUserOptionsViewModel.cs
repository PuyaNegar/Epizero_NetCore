using Common.Enums;
using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.FinancialsViewModels
{
    public class SalesPartnerUserOptionsViewModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مبلغ شناور (تومان)")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "درصد شناور همکاری")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [Range(0, 100, ErrorMessage = "مقدار وارد شده برای میزان تخفیف صحیح نمی‌باشد")]
        public int Percent { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "همکار فروش")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int SalesPartnerUserId { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "سهم از فروش همکار فروش")]
        public ActiveStatus SalePartnerIsPrepayment { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public string SalePartnerIsPrepaymentName { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public string SalesPartnerUserFullName { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دوره")]
        [Required(ErrorMessage = "دوره را انتخاب کنید")]
        public int CourseId  { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دوره")] 
        public string CourseName { get; set; }
        //=============================================
    }
}
