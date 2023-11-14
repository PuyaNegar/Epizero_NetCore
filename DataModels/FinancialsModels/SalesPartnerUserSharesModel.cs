using DataModels.Base;
using DataModels.IdentitiesModels;
using DataModels.OrdersModels;

namespace DataModels.FinancialsModels
{
    public class SalesPartnerUserSharesModel : ModifyDateTimeWithUserModel
    {
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public int Amount { get; set;  }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public int SalePartnerUserId { get; set;  }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel SalePartnerUser { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public int OrderDetailId { get; set;  }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual OrderDetailsModel OrderDetail  { get; set; }
        //==================================================
    }
}
