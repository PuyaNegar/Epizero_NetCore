using Common.Enums;
using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.FinancialsViewModels
{
    public class StudentDiscountsViewModel
    {
        //=================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع تخفیف")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public ActiveStatus IsDiscountPercent { get; set; }
        //=================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "درصدی/مبلغی")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int AmountOrPercent { get; set; }
        //================================================================= 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شرح سند")]
        public string Description { get; set; }
    }
}
