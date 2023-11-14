using DataModels.Base;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataModels.OnlineExamModels
{
    public class OnlineExamStudentsModel : ModifyDateTimeWithUserModel
    {
        public OnlineExamStudentsModel()
        {
            this.OnlineExamStudentAnswers = new HashSet<OnlineExamStudentAnswersModel>();
            this.OnlineExamStudentAnswerFiles = new HashSet<OnlineExamStudentAnswerFilesModel>();
            this.StudentOnlineExamResults = new HashSet<StudentOnlineExamResultsModel>();
        }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsFinalized { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsAbsentOnMainTime { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EnterDateTime { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public int OnlineExamId { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual OnlineExamsModel OnlineExam { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //======================================================== 
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FinalizedDateTime { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel StudentUser { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        //public int? CourseMeetingStudentId { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        //public virtual CourseMeetingStudentsModel CourseMeetingStudent { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OnlineExamStudentAnswersModel> OnlineExamStudentAnswers { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OnlineExamStudentAnswerFilesModel> OnlineExamStudentAnswerFiles { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StudentOnlineExamResultsModel> StudentOnlineExamResults { get; set; }
    }
}
