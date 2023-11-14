using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.IdentitiesViewModels
{
    public class ChangePasswordViewModel
    {
        //===================================================================================
        /// <summary>
        /// شناسه کاربری
        /// </summary>
        [Required]
        [Display(Name = "شناسه کاربری")]
        public int UserId { get; set; }

        //===================================================================================
        /// <summary>
        /// نام کاربری
        /// </summary>
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        //===================================================================================
        /// <summary>
        /// رمز عبور جديد
        /// </summary>
        [Display(Name = "کلمه عبور جديد")]
        [Required(ErrorMessage = "کلمه عبور نبایستی خالی باشد")]
        [MinLength(6, ErrorMessage = "کلمه عبور بایستی حداقل 6 کاراکتر باشد")]
        [MaxLength(16, ErrorMessage = "کلمه عبور بایستی حداکثر 16 کاراکتر باشد")]
        public string Password { get; set; }

        //===================================================================================
        /// <summary>
        /// تکرار رمز عبور جديد
        /// </summary>
        [Display(Name = "تکرار کلمه عبور جديد")]
        [Compare("Password", ErrorMessage = "تکرار کلمه عبور جدید با رمز عبور جدید یکسان نمی‌باشد")]
        public string RePassword { get; set; }
    }
}
