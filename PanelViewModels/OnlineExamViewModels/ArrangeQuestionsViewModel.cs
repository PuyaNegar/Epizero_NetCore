using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.OnlineExamViewModels
{
  public class ArrangeQuestionsViewModel
    {

        [Required(ErrorMessage = "{0} نبایستی خالی باشد")]
        public int QuestionId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [Required(ErrorMessage = "{0} نبایستی خالی باشد")]
        public int Inx  { get; set; }
    }
}
