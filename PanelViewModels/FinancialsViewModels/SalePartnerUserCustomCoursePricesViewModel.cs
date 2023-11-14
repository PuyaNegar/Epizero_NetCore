using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.FinancialsViewModels
{
  public  class SalePartnerUserCustomCoursePricesViewModel
    {
        public int Id { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دوره")]
        [Required(ErrorMessage = "دوره را انتخاب کنید")]
        public int CourseId { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دوره")]
        public string CourseName { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "همکار فروش")]
        [Required(ErrorMessage = "همکار فروش را انتخاب کنید")]
        public int SalePartnerUserId { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "همکار فروش")]
        public string SalePartnerUserName { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        [Display(Name = "مبلغ (تومان)")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int Price { get; set; }
    }
}
