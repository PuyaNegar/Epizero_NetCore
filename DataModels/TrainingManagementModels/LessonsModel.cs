using DataModels.Base; 
using DataModels.OnlineExamModels;
using System.Collections.Generic;

namespace DataModels.TrainingManagementModels
{
    public class LessonsModel : ModifyDateTimeWithUserModel
    {
        public LessonsModel()
        { 
            LessonTopics = new HashSet<LessonTopicsModel>();
            Questions = new HashSet<QuestionsModel>();
            OnlineExamQuestions = new HashSet<OnlineExamQuestionsModel>();
            StudentOnlineExamResults = new HashSet<StudentOnlineExamResultsModel>();
            Courses = new HashSet<CoursesModel>(); 
        }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public int UnitCount { get; set; }
        //====================================================================================== ارتباطات 
        /// <summary>
        /// 
        /// </summary>
        public int LevelId { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public int? FieldId { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual FieldsModel Field { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual LevelsModel Level { get; set; }
        //=======================================================  
        /// <summary>
        /// 
        /// </summary>
        public ICollection<LessonTopicsModel> LessonTopics { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<QuestionsModel> Questions { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<OnlineExamQuestionsModel> OnlineExamQuestions { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<StudentOnlineExamResultsModel> StudentOnlineExamResults { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<CoursesModel> Courses { get; set; }

    }
}
