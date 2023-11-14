using DataModels.Base;
using DataModels.IdentitiesModels;
using System;
namespace DataModels.TrainingManagementModels
{
    public class CourseStudentQuestionAnswersModel : ModifyDateTimeWithUserModel
    {
     
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public string AnswerContext { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public bool? IsVerified { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentQuestionId { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsBestAnswer { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime ? VerifiedDateTime { get; set; }
        //=============================================
         
        /// <summary>
        /// 
        /// </summary>
        public string AnswerPicPath { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        public string AnswerFilePath { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        public string AudioPath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseStudentQuestionsModel StudentQuestion { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public int AnsweredUserId { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel AnsweredUser { get; set; }
      
    }
}
