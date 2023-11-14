using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class WeekSchedulesViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //==================================================================
        /// <summary>
        /// ساعت شروع
        /// </summary>
        [Display(Name = "ساعت شروع")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد و فرمت ساعت باید بصورت ۱۲:۰۰ باشد")]
        [RegularExpression(pattern: @"^\d{2}:\d{2}$", ErrorMessage = "فيلد نبايستی خالی باشد و فرمت ساعت باید بصورت ۱۲:۰۰ باشد")]
        public string StartTime { get; set; }
        //==================================================================
        /// <summary>
        /// ساعت پایان
        /// </summary>
        [Display(Name = "ساعت پایان")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد و فرمت ساعت باید بصورت ۱۲:۰۰ باشد")]
        [RegularExpression(pattern: @"^\d{2}:\d{2}$", ErrorMessage = "فيلد نبايستی خالی باشد و فرمت ساعت باید بصورت ۱۲:۰۰ باشد")]
        public string EndTime { get; set; }
        //==================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "روز هفته")]
        [Required(ErrorMessage = "روز هفته انتخاب نشده است")]
        public int WeekDayId { get; set; }
        //================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "روز")]
        public string WeekDayName { get; set; }
        //=========================================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        [Display(Name = "وضعيت")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }

        //=========================================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        public string IsActiveName { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دوره")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public int CourseId { get; set; }
        //=========================================================
        /// <summary>
        /// دوره
        /// </summary>
        public string CourseName { get; set; }

    }
}
