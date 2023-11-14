 
namespace PanelViewModels.TrainingManagementViewModels
{
   public class StudentCourseQuestionAnswersViewModel
    {  
         
        /// <summary>
        /// 
        /// </summary>
        public string AnswerAudioPath { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string AnswerFilePath { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string AnswerPicPath { get; set; } 
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string  AnswerContext  { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string AnsweredUserFullName  { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string RegDateTime { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string ConfirmStatusType { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsBestAnswer { get; set;  }
    }
}
