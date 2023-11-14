using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.ContentsViewModels
{
   public class CourseNotificationsViewModel
    {
        public int Id { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public string IsActiveName { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [StringLength(300, ErrorMessage = "فیلد نبایستی بیشتر از 300 کاراکتر باشد")]
        public string Title { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ شروع  ")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فيلد نبايستی خالی باشد و فرمت تاریخ باید بصورت 1390/01/01 باشد")]
        public string FromDate { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ پایان  ")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فيلد نبايستی خالی باشد و فرمت تاریخ باید بصورت 1390/01/01 باشد")]
        public string ToDate { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
 
        //=======================================
        /// <summary>
        /// شناسه تگ‌های محصول
        /// </summary>
        [Display(Name = "نوتفیکشن های دوره")]
        public List<string> CourseNotificationIds { get; set; }
    }
}
