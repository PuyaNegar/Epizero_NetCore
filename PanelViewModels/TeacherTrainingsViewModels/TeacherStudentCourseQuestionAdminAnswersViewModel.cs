using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TeacherTrainingsViewModels
{
   public class TeacherStudentCourseQuestionAnswersViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int QuestionId  { get; set; }
        //================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "متن پاسخ")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public string AnswerContext { get; set; }
        //================================================
        
    }
}
