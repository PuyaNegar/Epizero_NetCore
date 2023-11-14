using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.OnlineExamViewModels
{
    public class OnlineExamStudentManualAnswersViewModel
    {
        public int OnlineExamStudentId { get; set; }
        public List<OnlineExamStudentManualAnswerSelectedOptionsViewModel> OnlineExamStudentManualAnswerSelectedOptions { get; set; }
    }

}
