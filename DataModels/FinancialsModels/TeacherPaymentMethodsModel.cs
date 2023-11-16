using DataModels.Base;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.FinancialsModels
{
   public class TeacherPaymentMethodsModel : ModifyDateTimeWithUserModel
    {
        public TeacherPaymentMethodsModel()
        {
            TeacherSattlementSchedules = new HashSet<TeacherSattlementSchedulesModel>();
        }
        //=================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int TeacherUserId { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public long TotalSattledAmount { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public long TotalDebtAmount { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public string Comment { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel TeacherUser { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual CoursesModel Course { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<TeacherSattlementSchedulesModel> TeacherSattlementSchedules { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public int TeacherPaymentMethodTypeId { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public virtual TeacherPaymentMethodTypesModel TeacherPaymentMethodType { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public virtual TeacherMeetingFeesModel TeacherMeetingFee { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public virtual TeacherPercentagesModel TeacherPercentage { get; set; }

    }
}
