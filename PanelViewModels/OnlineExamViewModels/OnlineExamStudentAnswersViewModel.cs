using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.OnlineExamsViewModels
{
    public class OnlineExamStudentAnswersViewModel
    {
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentFullName { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string ExamName { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<StudentOnlineExamQuestionsViewModel> StudentOnlineExamQuestions { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<OnlineExamStudentAnswerFilesViewModel> OnlineExamStudentAnswerFiles { get; set;  }
        //====================================================

    }
}
