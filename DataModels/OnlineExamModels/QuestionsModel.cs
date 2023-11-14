using DataModels.Base; 
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;

namespace DataModels.OnlineExamModels
{
    public class QuestionsModel : ModifyDateTimeWithUserModel
    {
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsTextQuestionContext { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string QuestionContext { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string QuestionContext_Html { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int? ResponseTime { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Source { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int QuestionTypeId { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual QuestionTypesModel QuestionType { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int DifficultyLevelTypeId { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual DifficultyLevelTypesModel DifficultyLevelType { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int QuestionMakerUserId { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel User { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary> 
        public int? LessonTopicId { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual LessonTopicsModel LessonTopic { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual DescriptiveQuestionsModel DescriptiveQuestion { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual MultipleChoiceQuestionsModel MultipleChoiceQuestion { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int LessonId { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual LessonsModel Lesson { get; set; }
    }
}
