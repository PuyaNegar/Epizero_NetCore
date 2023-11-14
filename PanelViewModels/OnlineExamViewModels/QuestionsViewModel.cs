using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.OnlineExamsViewModels
{
   public class QuestionsViewModel
    {
        public int Id { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [Display(Name = "متن سوال")]
        public string QuestionContext { get; set; }

    }
}
