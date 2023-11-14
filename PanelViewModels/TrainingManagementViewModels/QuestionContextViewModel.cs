using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class QuestionContextViewModel
    {
        [Display(Name = "متن پاسخ")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public string Context { get; set; }
        //==================================================
        [Display(Name = "آیا بهترین پاسخ است ؟")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public ActiveStatus IsBestAnswer { get; set; }
    }
}
