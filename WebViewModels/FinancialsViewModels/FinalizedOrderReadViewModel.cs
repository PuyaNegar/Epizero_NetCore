using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using WebViewModels.UtilityJsonConvertor;

namespace WebViewModels.FinancialsViewModels
{
    public class FinalizedOrderReadViewModel
    {
        //=====================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=====================================
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        //=====================================
        /// <summary>
        /// 
        /// </summary>
        public string RegDateTime { get; set; }
        //=====================================
        /// <summary>
        /// 
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int PaymentAmount { get; set; } 
        //===================================== 
      
        /// <summary>
        /// 
        /// </summary>
        public string StudentUserFullName { get; set; }
        //=====================================
        /// <summary>
        /// 
        /// </summary> 
        public int StudentUserId { get; set; }
        //=====================================
        
        /// <summary>
        /// شماره سفارش
        /// </summary> 
        public string InvoiceNo { get; set; }
        //========================================================== 
    }
}
