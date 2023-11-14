using System.Collections.Generic;
using System.Xml.Linq;
using DataModels.Base;
using DataModels.ContentsModels;
using DataModels.FinancialsModels;
using DataModels.OnlineExamModels;
using DataModels.TrainingManagementModels;

namespace DataModels.IdentitiesModels
{
    public class UsersModel : IdentifierModel
    {
        public UsersModel()
        {
            OnlineExams = new HashSet<OnlineExamsModel>();
            UserLoginHistories = new HashSet<UserLoginHistoriesModel>();
            CourseMeetingDedicatedTeachers = new HashSet<CourseMeetingDedicatedTeachersModel>();
            CourseMultiTeacherShares = new HashSet<CourseMultiTeacherSharesModel>();
            StudentUserMessages = new HashSet<StudentUserMessagesModel>();
            Invoices = new HashSet<InvoicesModel>();
            OldStudentComments = new HashSet<OldStudentCommentsModel>();
            CourseStudentQuestionLikes = new HashSet<CourseStudentQuestionLikesModel>();
            CourseStudentNewComments = new HashSet<CourseStudentNewCommentsModel>();
        }
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        public bool Gender { get; set; }
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        public string NationalCode { get; set; }
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        public string PasswoerdHash { get; set; }
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        public string PersonalPicPath { get; set; }
        //==========================================================
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        //========================================================== ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int UserGroupId { get; set; }
        //==========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UserGroupsModel UserGroup { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual StudentUserProfilesModel StudentUserProfile { get; set; }
        //===========================================================  

        /// <summary>
        /// 
        /// </summary>
        public virtual TeacherUserProfilesModel TeacherUserProfile { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OnlineExamsModel> OnlineExams { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<UserLoginHistoriesModel> UserLoginHistories { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseMeetingDedicatedTeachersModel> CourseMeetingDedicatedTeachers { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseMultiTeacherSharesModel> CourseMultiTeacherShares { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StudentUserMessagesModel> StudentUserMessages { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<InvoicesModel> Invoices { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OldStudentCommentsModel> OldStudentComments { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseStudentQuestionLikesModel>  CourseStudentQuestionLikes { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseStudentNewCommentsModel> CourseStudentNewComments { get; set; }
    }
}
