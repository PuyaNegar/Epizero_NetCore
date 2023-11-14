using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.ContentsViewModels
{
   public class TeacherSampleVideosViewModel
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
        [Display(Name = "اولویت نمایش")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^\d{0,5}$", ErrorMessage = "فیلد بایستی بصورت عددی و حداکثر ۵ رقمی باشد")]
        public int Inx { get; set; }
        //=============================================
        /// <summary>
        /// اولویت نمایش
        /// </summary>
        [Display(Name = "استاد")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int TeacherId { get; set; }
        //============================================
        /// <summary>
        /// اولویت نمایش
        /// </summary>
        [Display(Name = "استاد")]
        public string TeacherName { get; set; }
        //============================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }

        //============================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        public string IsActiveName { get; set; }
        //============================================
        /// <summary>
        /// لینک URL
        /// </summary>
        [Display(Name = "لینک URL")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        [StringLength(200, ErrorMessage = "لینک URL بایستی حداکثر 2000 کاراکتر باشد")]
        public string Link { get; set; }
        //=========================================================
        /// <summary>
        /// عنوان
        /// </summary>
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(150, ErrorMessage = "عنوان بایستی حداکثر 15۰ کاراکتر باشد")]
        public string Title { get; set; }
    }
}
