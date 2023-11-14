using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.ContentsViewModels
{
   public class OnlineExamPromosViewModel   
    {
        //=================================================
        /// <summary>
        /// شناسه محصول سکشن تبلیغاتی
        /// </summary>
        public int Id { get; set; }

        //=================================================
        /// <summary>
        /// شناسه محصول
        /// </summary>
        [Display(Name = "نام دوره")]
        public int CourseId { get; set; }
        //==================================================
        /// <summary>
        /// دانش آموز
        /// </summary>
        [Display(Name = "نام")]
        //[Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public string CourseIds { get; set; }
        //==================================================
        /// <summary>
        /// نام  
        /// </summary>
        public string CourseName { get; set; }

        //==================================================
        /// <summary>
        /// شناسه سکشن تبلیغاتی
        /// </summary>
        [Display(Name = "سکشن تبلیغاتی")]
        [Required(ErrorMessage = "فیلد سکشن تبلیغاتی نبایستی خالی باشد")]
        public int OnlineExamPromoSectionGroupId { get; set; }

        //==================================================
        /// <summary>
        /// سکشن تبلیغاتی
        /// </summary>
        public string OnlineExamPromoSectionGroupName { get; set; }

        //==================================================
        /// <summary>
        /// اولویت نمایش
        /// </summary>
        [Display(Name = "اولویت نمایش")]
        [Required(ErrorMessage = "فیلداولویت نمایش نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^\d{0,5}$", ErrorMessage = "فیلد بایستی بصورت عددی و حداکثر 5 رقمی باشد")]
        public int Inx { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public string TeacherFullName { get; set; }
    }
}
