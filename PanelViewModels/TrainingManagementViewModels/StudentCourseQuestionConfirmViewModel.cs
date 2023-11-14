using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class StudentCourseQuestionConfirmViewModel
    {
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "متن سوال")]
        public string QuestionContext { get; set;  }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ تایید")]
        public string VerifiedDateTime { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تأیید شده ؟")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public ActiveStatus? IsVerified { get; set;  }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ ثبت")]
        public string RegDateTime { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دانش آموز")]
        public string StudentUserFullName  { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دوره")]
        public string CourseName { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "فایل")]
        public string QuestionFilePath { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تصویر")]
        public string QuestionPicPath { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "صوت")]
        public string AudioPath { get; set; }

    }
}
