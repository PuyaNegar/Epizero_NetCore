using DataModels.Base;
using System; 

namespace DataModels.FinancialsModels
{
   public class StudentPosPaymentsModel : ModifyDateTimeWithUserModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string TrackingNo { get; set; }
        //============================================================================================ ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int BankPosDeviceId { get; set; }
        //====================================================
        ///<summary>
        /// 
        /// </summary>
        public virtual BankPosDevicesModel BankPosDevices { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentFinancialPaymentId { get; set; }
        //========================================
        /// <summary>
        /// 
        /// </summary>
        public virtual StudentFinancialPaymentsModel StudentFinancialPayment { get; set; }
    }
}
