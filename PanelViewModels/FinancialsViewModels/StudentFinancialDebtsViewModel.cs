using Common.Enums;
using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;

namespace PanelViewModels.FinancialsViewModels
{
   public class StudentFinancialDebtsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int  Id  { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public ActiveStatus IsOnlineRegistrated { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseName  { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseMeetingStudentType { get; set;  }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int DebtAmount { get; set;  }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentUserFullName  { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsCanceled { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string IsCanceledName { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int Price { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int SalePartnerPrice { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int DiscountAmount { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int TotalAmount { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string RegUserFullName { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public string DiscountDiscription { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public string UserEditor { get; set; }
    }
}
