using DataModels.Base; 
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using System.Collections.Generic;

namespace DataModels.OnlineExamModels
{
    public class OnlineExamQuestionsModel : ModifyDateTimeWithUserModel
    {
        public OnlineExamQuestionsModel()
        {
            this.OnlineExamStudentAnswers = new HashSet<OnlineExamStudentAnswersModel>(); 
        }
        //====================================================
        public bool IsTextQuestionContext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string QuestionContext { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string QuestionContext_CkFormat { get; set; }
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
        public int Inx { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=ارتباطات  
 
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
        public int OnlineExamId { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual OnlineExamsModel OnlineExam { get; set; }
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
        public virtual OnlineExamMultipleChoiceQuestionsModel OnlineExamMultipleChoiceQuestion { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual OnlineExamDescriptiveQuestionsModel OnlineExamDescriptiveQuestion { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OnlineExamStudentAnswersModel> OnlineExamStudentAnswers { get; set; }
 
    }
}
