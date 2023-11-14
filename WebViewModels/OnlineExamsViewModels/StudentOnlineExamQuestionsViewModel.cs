using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.OnlineExamsViewModels
{
   public class StudentOnlineExamQuestionsViewModel
    {
        public bool IsTextQuestionContext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string QuestionContext { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public int OnlineExamId { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public int QuestionTypeId { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string QuestionTypeName { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public int LessonId { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string LessonName { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public StudentDescriptiveAnswersViewModel DescriptiveAnswers { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public StudentMultipeChoiceAnswerViewModel MultipeChoiceAnswer { get; set;  }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public StudentMultipleChoiceQuestionOptionsViewModel MultipleChoiceQuestionOptions { get; set;  }
   
        //=======================================================
    }
}
