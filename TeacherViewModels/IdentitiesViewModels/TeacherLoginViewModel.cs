using System.ComponentModel.DataAnnotations;

namespace TeacherViewModels.IdentitiesViewModels
{
    public class TeacherLoginViewModel
    {
        //======================================================================
        /// <summary>
        /// نام کاربری
        /// </summary>
        [Display(Name = "شماره موبایل")]
        [RegularExpression(pattern: @"^0\d{10}$", ErrorMessage = "فرمت شماره موبایل صحیح وارد وارد شود بطور مثال 09149876543.")]
        [Required(ErrorMessage = "شماره موبایل نبایستی خالی باشد")]
        public string UserName { get; set; }

        //======================================================================
        /// <summary>
        /// کلمه عبور
        /// </summary>
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "کلمه عبور نباید خالی باشد")]
        public string Password { get; set; }
         

        //======================================================================
        /// <summary>
        /// مرا به خاطر بسپار
        /// </summary>
        [Display(Name = "مرا به خاطر بسپار")]
        public bool IsPersistent { get; set; }
    }
}
