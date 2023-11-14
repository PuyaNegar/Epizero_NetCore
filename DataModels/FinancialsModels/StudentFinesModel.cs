using DataModels.Base;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;

namespace DataModels.FinancialsModels
{
    public class StudentFinesModel : ModifyDateTimeWithUserModel
    {
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public int Amount { get; set;  }
        //====================================================== ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set;  }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel StudentUser { get; set; }
        //====================================================== ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int? CourseMeetingStudentId { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingStudentsModel CourseMeetingStudent  { get; set; }
        //======================================================
    }
}
