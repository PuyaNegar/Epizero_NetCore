using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TeacherTrainingsViewModels
{
    public class TeacherHomeworkAnswerGradesViewModel
    {
        //================================================
        /// <summary>
        /// 
        /// </summary>
 
        [Required(ErrorMessage = "فیلد  نبایستی خالی باشد")]
        public int HomeworkAnswerId   { get; set; }
        //================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نمره")]
        [Required(ErrorMessage = "نمره نبایستی خالی باشد")]
        

        public float Grade { get; set;  }
        //================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "فیلد  نبایستی خالی باشد")]
        public int StudentuserId  { get; set; }
    }
}
