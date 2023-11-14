
using Newtonsoft.Json;
using WebViewModels.UtilityJsonConvertor;

namespace WebViewModels.FinancialsViewModels
{
   public class StudentFinancialPosPaymentsViewModel
    {
        //==================================================
        /// <summary>
        /// 
        /// </summary>
       // public int BankPosDeviceName { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public string TrackingNo { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int AmountPaid { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentUserName { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public string RegDateTime { get; set; }
    }
}
