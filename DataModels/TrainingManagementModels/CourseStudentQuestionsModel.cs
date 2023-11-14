using DataModels.Base;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic; 

namespace DataModels.TrainingManagementModels
{
    public class CourseStudentQuestionsModel : ModifyDateTimeWithUserModel
    {
        //=============================================
        public CourseStudentQuestionsModel()
        {
            StudentQuestionAnswers = new HashSet<CourseStudentQuestionAnswersModel>();
            CourseStudentQuestionLikes = new HashSet<CourseStudentQuestionLikesModel>();
        } 
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public string QuestionContext { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public bool? IsVerified { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime? VerifiedDateTime { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public int UnVerifyAnswerCount { get; set; } 
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel StudentUser { get; set; }
        //=============================================
       /// <summary>
       /// 
       /// </summary>
        public int CourseId { get;set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CoursesModel Course { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public string QuestionPicPath { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        public string QuestionFilePath { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        public string AudioPath { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<CourseStudentQuestionAnswersModel> StudentQuestionAnswers { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseStudentQuestionLikesModel> CourseStudentQuestionLikes { get; set; }
    }
}
