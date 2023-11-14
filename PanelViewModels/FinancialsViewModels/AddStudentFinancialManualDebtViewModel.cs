using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.FinancialsViewModels
{
   public class AddStudentFinancialManualDebtViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مبلغ ")]
        [Required(ErrorMessage = "مبلغ پرداخت شده نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int DebtAmount { get; set; }
        //===============================================
        /// <summary>
        //
        /// </summary>
        [Display(Name = "شرح سند")]
        public string Description { get; set; }
        //===================================================
        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = " تاریخ ثبت نبایستی خالی باشد")]
        [RegularExpression(@"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فرمت تاریخ بایستی بصورت 1390/05/06 باشد")]
        public string RegDateTime { get; set; }
    }
}
