using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.IdentitiesViewModels
{
    public class AdminUsersViewModel
    {
        //===============================================================================
        /// <summary>
        /// شناسه مشتری
        /// </summary>
        public int Id { get; set; }
        //===============================================================================
        /// <summary>
        /// نام کاربری 
        /// </summary>
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^\w+$", ErrorMessage = "فرمت نام کاربری صحیح نمی باشد")]
        [StringLength(30 , ErrorMessage =  "فیلد بایستی حداکثر 30 کاراکتر باشد")]
        public string UserName { get; set; }
        //===============================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [MinLength(6, ErrorMessage = "فیلد بایستی بیش از 6 کاراکتر باشد")]
        [MaxLength(16, ErrorMessage = "فیلد بایستی کمتر از 16 کاراکتر باشد")]
        public string Password { get; set; }
        //===============================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [MinLength(6, ErrorMessage = "فیلد بایستی بیش از 6 کاراکتر باشد")]
        [MaxLength(16, ErrorMessage = "فیلد بایستی کمتر از 16 کاراکتر باشد")]
        [Compare("Password", ErrorMessage = "تکرار کلمه عبور جدید با رمز عبور جدید یکسان نمی‌باشد")]
        public string RepPassword { get; set; }
        //===============================================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "فیلد نبایستی خالی نباشد")]
        [Display(Name = "گروه کاربری")]
        public int UserGroupId { get; set; }
        //===============================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "گروه کاربری")]
        public string UserGroupName  { get; set; }
        //===============================================================================
        /// <summary>
        /// 
        /// </summary>
        public string IsActiveName { get; set; }
        //===============================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "وضعیت کاربری")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "جنسیت کاربری")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public ActiveStatus Gender { get; set; }
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "جنسیت کاربری")]
        public string GenderName { get; set; }
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "فیلد بایستی حداکثر 100 کاراکتر باشد")]
        public string FirstName { get; set; }
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "فیلد بایستی حداکثر 100 کاراکتر باشد")]
        public string LastName { get; set; }

        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "کد ملی")]
        //[Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [RegularExpression(@"^\d{10}$" , ErrorMessage = "کد ملی بایستی بصورت 10 رقمی وارد شود")]
        public string NationalCode  { get; set; }
        //=============================================================================
    }
}
