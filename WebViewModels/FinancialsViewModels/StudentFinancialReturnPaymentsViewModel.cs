
using Newtonsoft.Json;
using WebViewModels.UtilityJsonConvertor;

namespace WebViewModels.FinancialsViewModels
{
    public class StudentFinancialReturnPaymentsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary> 
        public string Description { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary> 
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int ReturnAmount { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary> 
        public int ReturnPaymentTypeId { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        
        public string ReturnPaymentTypeName { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentUserFullName { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string AmountPaidDateTime { get; set; }
        //====================================================
    }
}
