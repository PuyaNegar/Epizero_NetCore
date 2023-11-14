using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.FinancialsViewModels
{
    public class AddChequePaymentsViewModel
    {
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شرح سند")]
        public string Description { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مبلغ پرداخت شده (تومان)")]
        [Required(ErrorMessage = "مبلغ پرداخت شده نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int AmountPaid { get; set; }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "چک را انتخاب کنید")]
        [Display(Name = "انتخاب چک")]
        public int PaidChequeId { get; set; }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مبلغ باقیمانده چک (تومان)")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int RemainingAmount { get; set; }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        public string PaidChequeName { get; set; }
    }
}
