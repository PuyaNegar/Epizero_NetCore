using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.FinancialsViewModels
{
    public class SalesPartnerUserSharesViewModel
    {
        public int Id { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public string DiscountCode { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentFullName { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public string SalesPartnerShareTypeName { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public int LessonsUsedCount { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int SumOfSalePartnerShares { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
       public string SalePartnerIsPrePayment { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int SalePartnerAmountOrPercent { get; set; }
        //==================================================
    }
}
