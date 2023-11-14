using System.Collections.Generic;
using DataModels.Base;

namespace DataModels.FinancialsModels
{
    public class BanksModel : ModifyDateTimeWithUserModel
    {
        //=================================================================
        public BanksModel()
        { 
            PaidCheques = new HashSet<PaidChequesModel>();
            BankPosDevices = new HashSet<BankPosDevicesModel>();
        }
        //====================================================
        ///<summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //==================================================================ارتباطات
        ///<summary>
        /// 
        /// </summary>
        public virtual ICollection<PaidChequesModel> PaidCheques { get; set; }
        //=================================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<BankPosDevicesModel> BankPosDevices  { get; set; }
        //=================================================================
    }
}
