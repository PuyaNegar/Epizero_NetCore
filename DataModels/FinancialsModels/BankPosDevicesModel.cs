using DataModels.Base;
using System.Collections;
using System.Collections.Generic;

namespace DataModels.FinancialsModels
{
    public class BankPosDevicesModel : ModifyDateTimeWithUserModel
    {
        public BankPosDevicesModel()
        {
            PosPayments = new HashSet<StudentPosPaymentsModel>();
        }
        //============================================================================================
        /// <summary>
        /// 
        /// </summary>
        public string AccountNo { get; set; }
        //============================================================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //============================================================================================ ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int BankId { get; set; }
        //====================================================
        ///<summary>
        /// 
        /// </summary>
        public virtual BanksModel Bank { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StudentPosPaymentsModel> PosPayments { get; set; }
    }
}
