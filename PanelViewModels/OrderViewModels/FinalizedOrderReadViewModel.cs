using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.OrderViewModels
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
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int DiscountCodeAmount { get; set; }
        //========================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string AcademyProductTypeName { get; set; }
        //========================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string AcademyProductName { get; set; }
    }
}
