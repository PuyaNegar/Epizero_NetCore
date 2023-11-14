using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class StudentCourseQuestionAdminAnswersViewModel
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
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [Display(Name = "آیا بهترین پاسخ است ؟")]
        public ActiveStatus IsBestAnswer  { get; set; }
        //================================================
 

        /// <summary>
        /// 
        /// </summary>
        public string AnswerPicPath { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        public string AnswerFilePath { get; set; }
        //==============================================  
        /// <summary>
        /// 
        /// </summary>
        public string AudioPath { get; set; }
    }
}
