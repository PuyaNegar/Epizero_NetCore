using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.IdentitiesViewModels
{
   public class StudentUserMessagesViewModel
    {
        public int Id { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
 
        [Display(Name = "وضعیت پاسخ")]
        public bool IsAnswered { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
 
        [Display(Name = "متن سوال")]
        public string QuestionText { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "متن پاسخ نبايستی خالی باشد")]
        [Display(Name = "متن پاسخ")]
        public string AnsweredQuestionText { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
 
        [Display(Name = "تاریخ ثبت پاسخ")]
        public string AnsweredDateTime { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
 
        [Display(Name = "تاریخ ثبت سوال")]
        public string RegDateTime { get; set; }

        //=============================================================
        /// <summary>
        ///  
        /// </summary>
 
        [Display(Name = "نام نام خانوادگی")]
        public string StudentUserFullName { get; set; }
 
    }
}
