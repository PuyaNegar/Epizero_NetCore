using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.ContentsViewModels
{
   public class CoursePromoSectionsViewModel
    {
        //============================================
        /// <summary>
        /// شناسه سکشن تبلیغاتی
        /// </summary>
        public int Id { get; set; }

        //============================================
        /// <summary>
        /// اولویت نمایش
        /// </summary>
        [Display(Name = "اولویت نمایش")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^\d{0,5}$", ErrorMessage = "فیلد بایستی بصورت عددی و حداکثر 5 رقمی باشد")]
        public int Inx { get; set; }

        //============================================
        /// <summary>
        /// عنوان
        /// </summary>
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(50, ErrorMessage = "عنوان جایگزین بایستی حداکثر 5۰ کاراکتر باشد")]
        public string Title { get; set; }

        //============================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }

        //=========================================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        public string IsActiveName { get; set; }
    }
}
