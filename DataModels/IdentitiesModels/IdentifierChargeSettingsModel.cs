using DataModels.Base;

namespace DataModels.IdentitiesModels
{
    public class IdentifierChargeSettingsModel : ModifyDateTimeWithUserModel
    {
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public int IdentifierChargeAmount { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public int RegisteredUserChargeAmount {get;set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set;  }
        //=================================================
    }
}
