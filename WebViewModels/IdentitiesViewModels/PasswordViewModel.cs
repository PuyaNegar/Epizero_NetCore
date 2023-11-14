using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebViewModels.IdentitiesViewModels
{
    public class PasswordViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "شناسه نبایستی خالی باشد")]
        public string HashId { get; set; }
        //=======================================================================
        /// <summary>
        /// 
        /// </summary> 
        [RegularExpression(pattern: @"^\d{10}$", ErrorMessage = "فرمت شماره موبایل بایستی 10 رقمی و بدون صفر شروع شود")]
        [Required(ErrorMessage = "نام کاربری نبایستی خالی باشد")]
        public string UserName { get; set; } 
        //=======================================================================
        /// <summary>
        /// کلمه عبور جديد
        /// </summary>
        [Display(Name = "کلمه عبور جديد")]
        [Required(ErrorMessage = "کلمه عبور نبایستی خالی باشد")]
        [MinLength(6, ErrorMessage = "کلمه عبور بایستی حداقل 6 کاراکتر باشد")]
        [MaxLength(16, ErrorMessage = "کلمه عبور بایستی حداکثر 16 کاراکتر باشد")]
        public string Password { get; set; }

        //=======================================================================
        /// <summary>
        /// تکرار کلمه عبور جديد
        /// </summary>
        [Display(Name = "تکرار کلمه عبور جديد")]
        [Compare("Password", ErrorMessage = "تکرار کلمه عبور جدید با کلمه عبور جدید یکسان نمی‌باشد")]
        public string RePassword { get; set; }
    }
}
