using PanelViewModels.OnlineExamsViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.OnlineExamViewModels
{
    public class OnlineExamQuestionGroupsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int LessonId { get; set;  }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string LessonName  { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public List<OnlineExamQuestionsViewModel> OnlineExamQuestions { get; set;  }
        //========================================================= 
    }
}
