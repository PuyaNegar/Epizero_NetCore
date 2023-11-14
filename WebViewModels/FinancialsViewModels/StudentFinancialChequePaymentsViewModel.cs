using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebViewModels.UtilityJsonConvertor;

namespace WebViewModels.FinancialsViewModels
{
   public class StudentFinancialChequePaymentsViewModel
    {
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public string DueDate { get; set;  }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public string Description  { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public string ChequeNo  { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int AmountPaid { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public string Bank { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId  { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        public string RegDateTime { get; set; }
    }
}
