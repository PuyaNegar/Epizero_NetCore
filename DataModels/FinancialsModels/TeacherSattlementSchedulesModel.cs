using DataModels.Base;
using System; 
namespace DataModels.FinancialsModels
{
   public class TeacherSattlementSchedulesModel : ModifyDateTimeWithUserModel
    {
 
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsSettled { get; set; }

        //==========================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public virtual TeacherSattlementsModel TeacherSattlement { get; set; }
        //========================================
        /// <summary>
        /// 
        /// </summary>
        public int TeacherPaymentMethodId { get; set; }
        //========================================
        /// <summary>
        /// 
        /// </summary>
        public virtual TeacherPaymentMethodsModel TeacherPaymentMethod { get; set; }
    }
}
