using DataModels.Base;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;

namespace DataModels.FinancialsModels
{
    public class StudentFinancialReturnPaymentsModel : ModifyDateTimeWithUserModel
    { 
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public int ReturnAmount { get; set;  }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //============================================================================ ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int ReturnPaymentTypeId { get; set;  }
        //=================================================== 
        /// <summary>
        /// 
        /// </summary>
        public virtual ReturnPaymentTypesModel ReturnPaymentType { get; set;  }
        //=================================================== 
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel StudentUser { get; set;  }
        //========================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId  { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public int? CourseMeetingStudentId { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingStudentsModel CourseMeetingStudent { get; set; }
        //======================================================




    }
}
