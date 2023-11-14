
using System.Collections.Generic;

namespace PanelViewModels.OnlineExamViewModels
{
   public class OnlineExamAnsweringPercentageGroupsViewModel
    {
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string LessonName  { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public List<OnlineExamAnsweringPercentagesViewModel> OnlineExamAnsweringPercentages { get; set;  }
    }
}
