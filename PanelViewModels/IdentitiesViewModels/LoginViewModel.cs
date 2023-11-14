using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.IdentitiesViewModels
{
    public class LoginViewModel
    {
        //======================================================================
        /// <summary>
        /// نام کاربری
        /// </summary>
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        //======================================================================
        /// <summary>
        /// کلمه عبور
        /// </summary>
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "کلمه عبور نباید خالی باشد")]
        public string Password { get; set; }

        //======================================================================
        /// <summary>
        /// کپچا
        /// </summary>
        [Display(Name = "کپچا")]
        public string CaptchText { get; set; }

        //======================================================================
        /// <summary>
        /// مرا به خاطر بسپار
        /// </summary>
        [Display(Name = "مرا به خاطر بسپار")]
        public bool IsPersistent { get; set; }
    }
}
