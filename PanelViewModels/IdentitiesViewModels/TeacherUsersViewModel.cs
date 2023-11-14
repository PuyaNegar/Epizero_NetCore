using System.ComponentModel.DataAnnotations;
using Common.Enums; 

namespace PanelViewModels.IdentitiesViewModels
{
    public class TeacherUsersViewModel
    {
        [Display(Name = "توضیحات متا ")]
        [StringLength(3000, ErrorMessage = "فیلد نبایستی بیش از 3000 کاراکتر باشد")]
        public string MetaDescription { get; set; }
        //*******************************************************************
        /// <summary>
        /// شناسه  کاربر
        /// </summary>
        public int Id { get; set; }
        //*******************************************************************
        /// <summary>
        /// نام کاربر
        /// </summary>
        [Display(Name = "نام ")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [StringLength(20, ErrorMessage = "فیلد نبایستی بیش از 20 کاراکتر باشد")]
        public string FirstName { get; set; }
        //*******************************************************************
        /// <summary>
        /// نام خانوادگی کاربر
        /// </summary>
        [Display(Name = "نام خانوادگی ")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public string LastName { get; set; }
        //*******************************************************************
        /// <summary>
        ///    مهارت
        /// </summary>
        [Display(Name = "مهارت ")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "فیلد نبایستی بیش از 100 کاراکتر باشد")]
        public string Skill { get; set; }
        //*******************************************************************
        /// <summary>
        ///توضیحات
        /// </summary>
        [Display(Name = "توضیحات")]
        [StringLength(100, ErrorMessage = "فیلد نبایستی بیش از 2000 کاراکتر باشد")]
        public string Description { get; set; }
        //*******************************************************************
        /// <summary>
        /// جنسیت
        /// </summary>
        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public ActiveStatus Gender { get; set; }
        //*******************************************************************
        /// <summary>
        /// نام کاربری
        /// </summary>
        [Display(Name = "نام کاربری(شماره موبایل)")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "نام کاربری بایستی شماره موبایل و بصورت 11 رقمی باشد بطور مثال 09141002233")]
        public string UserName { get; set; }
        //*******************************************************************
        /// <summary>
        /// وضعیت کاربر
        /// </summary>
        [Display(Name = "وضعیت ")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public string IsActiveName { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public string GenderName { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تصویر ")]
        public string PersonalPicPath { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "بنر")]
        public string BannerPicPath { get; set; }
        //===================================================================  
        /// <summary>
        /// کد ملی
        /// </summary>
        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^\d{10}$", ErrorMessage = "کد ملی را با فرمت صحیح وارد کنید")]
        public string NationalCode { get; set; }
        //===================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = " آدرس ایمیل")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "آدرس ايميل معتبر نمی‌باشد")]
        [StringLength(100, ErrorMessage = "فیلد نبایستی بیش از 200 کاراکتر باشد")]
        public string Email { get; set; }
        //===================================================================
        /// <summary>
        /// تاریخ تولد
        /// </summary>
        [Display(Name = "تاریخ تولد")]
        [RegularExpression(@"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فرمت تاریخ صحیح نمی باشد.")]
        public string BirthDay { get; set; }
        //===================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شهر ")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public int CityId { get; set; } 
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string CityName { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "پسوند اساتید")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public int TeacherPrefixId { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "پسوند اساتید")] 
        public int TeacherUserPrefixName { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "آیا پیامک فعال باشد ؟ ")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public ActiveStatus IsEnabledSms  { get; set; }
        //=================================================================== 
        /// <summary>
        /// بخش مالی را برای دبیر فعال باشد ؟
        /// </summary>
        [Display(Name = "بخش مالی را برای دبیر فعال باشد ؟")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")] 
        public ActiveStatus IsShowFinancial { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع فعالیت")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int TeacherUserTypeId { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
 
        public string TeacherUserTypeName { get; set; }


        public string FullName { get; set; }
    }


}
