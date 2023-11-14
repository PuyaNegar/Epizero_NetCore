

using DataModels.TrainingManagementModels;

namespace DataModels.OnlineExamModels
{
   public class StudentOnlineExamResultsModel
    {
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int Unanswered { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int CorrectAnswered { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int IncorrectAnswered { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public float RawScore { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public float MaxScore { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public float MinScore { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int LessonRank { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int ParticipantsCount { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public float AvrageScore { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int TotalRank { get; set;  }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public decimal Balance { get; set;  }

        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public decimal AvrageBalance { get; set; }
        //==================================================== ارتباطات
        /// <summary>
        /// 
        /// </summary> 
        public int LessonId { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual LessonsModel Lesson { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int OnlineExamStudentId { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual OnlineExamStudentsModel OnlineExamStudent { get; set; }
    }
}
