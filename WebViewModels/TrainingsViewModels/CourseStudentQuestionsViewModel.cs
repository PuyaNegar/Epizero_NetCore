using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.TrainingsViewModels
{
   public class CourseStudentQuestionsViewModel
    {
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentUserFullName  { get; set; }
        public string StudentUserPicPath { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string RegDateTime { get; set;  }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string QuestionContext { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public int NoBestAnswerCount { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string ConfirmStatusType { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public int BestAnswerCount { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string QuestionPicPath { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string QuestionFilePath { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string AudioPath { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public List<CourseStudentQuestionAnswersViewModel> CourseStudentQuestionAnswers { get; set; }
        //=========================================================
    }
}
