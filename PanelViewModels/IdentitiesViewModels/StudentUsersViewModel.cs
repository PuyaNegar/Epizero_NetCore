using System.ComponentModel.DataAnnotations;
using Common.Enums; 

namespace PanelViewModels.IdentitiesViewModels
{
    public class StudentUsersViewModel
    {
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
        [StringLength(20 , ErrorMessage = "فیلد نبایستی بیش از 20 کاراکتر باشد")]
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
        /// جنسیت
        /// </summary>
        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]

        public ActiveStatus Gender { get; set; }
        //*******************************************************************
        /// <summary>
        /// تاریخ تولد
        /// </summary>
        [Display(Name = "تاریخ تولد")]
        //[RegularExpression(@"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فرمت تاریخ صحیح نمی باشد.")]
        public string BirthDay { get; set; }
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
        [Display(Name = "شماره موبایل پدر")]
        //[Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "فیلد نبایستی بیش از 100 کاراکتر باشد")]
        [RegularExpression(@"^\d{11}$" , ErrorMessage = "شماره موبایل بایستی بصورت 11 رقمی باشد بطور مثال 09141002233")]
        public  string FatherMobNo { get; set; }
        //===================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شماره موبایل مادر")]
        [StringLength(100, ErrorMessage = "فیلد نبایستی بیش از 100 کاراکتر باشد")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "شماره موبایل بایستی بصورت 11 رقمی باشد بطور مثال 09141002233")]
        public string MotherMobNo { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام مدرسه")]
        [StringLength(100, ErrorMessage = "فیلد نبایستی بیش از 100 کاراکتر باشد")]
        public string  SchoolName { get; set; } 
        //===================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = " آدرس ایمیل")]
        [RegularExpression(pattern: @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "آدرس ايميل معتبر نمی‌باشد")]
        [StringLength(100, ErrorMessage = "فیلد نبایستی بیش از 100 کاراکتر باشد")]
        public string Email { get; set; } 
        //===================================================================
        /// <summary>
        /// 
        /// </summary>
        public string  FullName { get; set; }
        //=================================================================
        /// <summary>
        /// کد ملی
        /// </summary>
        [Display(Name = "کد ملی")]
        //[Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^\d{10}$", ErrorMessage = "کد ملی را با فرمت صحیح وارد کنید")]
        public string NationalCode { get; set; }
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
        [Display(Name = "شغل مورد علاقه")]
        [StringLength(300, ErrorMessage = "فیلد نبایستی بیش از 300 کاراکتر باشد")]
        public string FavoriteJob { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شهر ")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")] 
        public int? CityId  { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شهر ")]
        public string CityName  { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع مدرسه ")] 
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public int? SchoolTypeId { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string SchoolTypeName { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نحوه آشنایی")]
        public int? IntroductionWithAcademyTypeId { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نحوه آشنایی")]
        public int? IntroductionWithAcademyTypeName { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "رشته")]
        public int? FeildId { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "پایه تحصیلی")]
        public int? LevelId { get; set; }

        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "رشته")]
        public string FeildName { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تصویر کارت ملی")]
        public string NationalCardPicPath { get; set; }
        //=================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شماره تلفن منزل")]
        [StringLength(20, ErrorMessage = "فیلد {0} نبایستی بیش از 20 کاراکتر باشد")]
        public string HomePhoneNumber { get; set; }

    }
}
