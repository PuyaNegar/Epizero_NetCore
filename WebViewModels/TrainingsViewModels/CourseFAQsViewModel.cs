using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace WebViewModels.TrainingsViewModels
{
    public class CourseFAQsViewModel
    {
        //============================================
        /// <summary>
        /// شناسه اسلایدر
        /// </summary>
        public int Id { get; set; }
        //============================================
        /// <summary>
        /// اولویت نمایش
        /// </summary>
        [Display(Name = "سوال")]
        public string QuestionContext { get; set; }
        //============================================
        /// <summary>
        /// عنوان
        /// </summary>
        [Display(Name = "پاسخ")]
        public string AnswerContext { get; set; }
        //============================================
        /// <summary>
        /// لینک URL
        /// </summary>
        [Display(Name = "اولویت نمایش")]
        public int Inx { get; set; }
 
    }
}
