using DataModels.Base;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;

namespace DataModels.FinancialsModels
{
    public class SalesPartnerUserOptionsModel : ModifyDateTimeWithUserModel
    { 
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public int Amount { get; set; }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public int Percent { get; set; }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public int SalesPartnerUserId { get; set; }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel SalesPartnerUser { get; set;  }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public bool SalePartnerIsPrepayment { get; set; }
        //================================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseId { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CoursesModel Course { get; set; }
        //=================================================
    }
}
