using Newtonsoft.Json;
using WebViewModels.UtilityJsonConvertor;

namespace WebViewModels.FinancialsViewModels
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
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int TotalAmount { get; set; }
        //==================================================== 
        /// <summary>
        /// 
        /// </summary>
        public bool IsCanceled { get; set; }
        //==================================================== 
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int DiscountAmount { get; set; }
    }
}
