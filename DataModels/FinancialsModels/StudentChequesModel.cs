using DataModels.Base;
using System; 

namespace DataModels.FinancialsModels
{
   public class StudentChequesModel : ModifyDateTimeWithUserModel
    {
        //============================================================================================ ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int PaidChequeId { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual PaidChequesModel PaidCheque { get; set; }
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
