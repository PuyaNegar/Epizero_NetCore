using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebViewModels.ContentsViewModels
{
  public  class ContactUsViewModel
    {

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام نام خانوادگی")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [StringLength(300, ErrorMessage = "فیلد نام خانوادگی بایستی کمتر از 100 کاراکتر باشد.")]
        public string FullName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "ایمیل")]
        [StringLength(100, ErrorMessage = "فیلد ایمیل بایستی کمتر از 100 کاراکتر باشد.")]
        [RegularExpression(pattern: @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "آدرس ايميل معتبر نمی‌باشد")]
        public string Email { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [StringLength(11, ErrorMessage = "فیلد موبایل بایستی کمتر از 11 کاراکتر باشد.")]
        [RegularExpression(pattern: @"^09\d{9}$", ErrorMessage = "شماره موبایل معتبر نمی‌باشد")]
        public string MobNo { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [StringLength(300, ErrorMessage = "فیلد پیام بایستی کمتر از 300 کاراکتر باشد.")]
        public string Description { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شناسه دوره")]
        public int? CoursesId { get; set; }
        //======================================================================
        /// <summary>
        /// کپچا
        /// </summary>
        [Display(Name = "کپچا")]
        public string CaptchText { get; set; }
    }
}
