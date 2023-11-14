using DataModels.Base;
using DataModels.BasicDefinitionsModels;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;

namespace DataModels.FinancialsModels
{
    public class CourseMultiTeacherSharesModel : ModifyDateTimeWithUserModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int AmountOrPercent { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public int TeacherUserId { get; set; } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public bool IsIndexTeacher { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel TeacherUser { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public int CourseId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public virtual CoursesModel Course { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public int CourseMultiTeacherShareTypeId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMultiTeacherShareTypesModel CourseMultiTeacherShareType { get; set; }

    }
}
