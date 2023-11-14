using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebViewModels.IdentitiesViewModels
{
   public class StudentUserMessagesViewModel
    {
        public int Id { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsAnswered { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "متن پاسخ نبايستی خالی باشد")]
        public string QuestionText { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        
        public string AnsweredQuestionText { get; set; }
     
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public string RegDateTime { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public string AnsweredDateTime { get; set; }
        //=============================================================
        /// <summary>
        ///  
        /// </summary>
        public string StudentUserFullName { get; set; }
        //=============================================================
        /// <summary>
        ///  
        /// </summary>
        public string AnsweredUserFullName { get; set; }
    }
}
