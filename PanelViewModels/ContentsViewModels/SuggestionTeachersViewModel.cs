using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.ContentsViewModels
{
   public class SuggestionTeachersViewModel
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
        public int TeacherUserId { get; set; }
        //============================================
        /// <summary>
        /// اولویت نمایش
        /// </summary>
        [Display(Name = "استاد")]
        public string TeacherUserName { get; set; }
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
    }
}
