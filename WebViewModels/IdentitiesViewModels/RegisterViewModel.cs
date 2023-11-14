using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebViewModels.IdentitiesViewModels
{
    public  class RegisterViewModel
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
        [RegularExpression(pattern: @"^0\d{10}$", ErrorMessage = "فرمت شماره موبایل صحیح وارد وارد شود بطور مثال 09149876543.")]
        [Required(ErrorMessage = "شماره موبایل نبایستی خالی باشد")]
        public string UserName { get; set; }
        //=======================================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "رمز عبور نبایستی خالی باشد")]
        [MinLength(6, ErrorMessage = "رمز عبور بایستی حداقل 6 کاراکتر باشد")]
        [MaxLength(16, ErrorMessage = "رمز عبور بایستی حداقل 16 کاراکتر باشد")]
        public string Password { get; set; }
        //=======================================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "تکرار رمز عبور نبایستی خالی باشد")]
        [Compare("Password", ErrorMessage = "پسورد ها یکسان نمی باشند")]
        public string RePassword { get; set; }
        //=======================================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "نام نبایستی خالی باشد")]
        [StringLength(20, ErrorMessage = "نام خانوادگی نبایستی بیش از 100 کاراکتر باشد")]
        public string FirstName { get; set; }
        //=======================================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "نام خانوادگی نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "نام خانوادگی نبایستی بیش از 100 کاراکتر باشد")]
        public string LastName { get; set; }
        //=======================================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "جنسیت نبایستی خالی باشد")]
        public ActiveStatus Gender { get; set; }
        //=======================================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "کد ملی نبایستی خالی باشد")]
        [RegularExpression(@"^(\d{11})|(\d{10})$", ErrorMessage = "کد ملی صحیح نمی باشد")]
        public string NationalCode { get; set; }
        //=======================================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "کد ملی نبایستی خالی باشد")]
        public string ConfirmCode { get; set; }
        //=======================================================================
        /// <summary>
        /// 
        /// </summary>
        public string IdentifierUserHashId { get; set; }
    }
}
