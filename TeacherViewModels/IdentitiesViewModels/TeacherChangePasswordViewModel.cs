using System.ComponentModel.DataAnnotations;

namespace TeacherViewModels.IdentitiesViewModels
{
    public class TeacherChangePasswordViewModel
    {
        //=======================================================================
        /// <summary>
        /// کلمه عبور فعلی
        /// </summary>
        [Display(Name = "کلمه عبور فعلی")]
        [Required(ErrorMessage = "کلمه عبور نبایستی خالی باشد")]
        public string OldPassword { get; set; }

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
