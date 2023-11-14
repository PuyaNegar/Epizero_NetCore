using Newtonsoft.Json;
using WebViewModels.UtilityJsonConvertor;

namespace WebViewModels.FinancialsViewModels
{
    public class StudentFinancialPaymentsViewModel
    {
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int AmountPaid { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentUserFullName { get; set; }
        //======================================= 
        /// <summary>
        /// 
        /// </summary>
        public string StudentFinancialPaymentType { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentFinancialPaymentTypeId { get; set; }
        //======================================= 
        /// <summary>
        /// 
        /// </summary>
        public string AmountPaidDateTime { get; set; }
        //======================================= 
        /// <summary>
        /// 
        /// </summary>
        public int? ChequeId { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public int? PosPaymentId { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        //public int? ReturnPaymentsId { get; set; }
    }
}
