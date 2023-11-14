using Common.Enums;
using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
  public class CoursesViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تعداد جلسه")]
        //[Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(300, ErrorMessage = "نام باید کمتر از {1} کاراکتر باشد")]
        public string CourseMeetingCount { get; set; }
        //=====================================================
        /// <summary>
        /// مخاطبین
        /// </summary>
        [Display(Name = "مخاطبین")]
        //[Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(300, ErrorMessage = "نام باید کمتر از {1} کاراکتر باشد")]
        public string Audience { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "نام باید کمتر از {1} کاراکتر باشد")]
        public string Name { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات")]

        public string Description { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تصویر بکگراند")]
        public string BannerPicPath { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تصویر زمینه")]
        public string LogoPicPath { get; set; }
        //================================================================= 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "  نوع دوره / آزمون / جزوه،کتاب ")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int CourseTypeId { get; set; }
        //=====================================================
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int Price { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مدت دوره (ساعت)")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int CourseDuration { get; set; }
        //===================================================== 
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        [Display(Name = "تاریخ شروع")] 
        [RegularExpression(pattern: @"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فيلد نبايستی خالی باشد و فرمت تاریخ باید بصورت 1390/01/01 باشد")]
        public string StartDate { get; set; }
        //=========================================================
        /// <summary>
        /// تاریخ پايان
        /// </summary>
        [Display(Name = "تاریخ پایان")] 
        [RegularExpression(pattern: @"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فيلد نبايستی خالی باشد و فرمت تاریخ باید بصورت 1390/01/01 باشد")]
        public string EndDate { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string CourseGroupName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "استاد")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int TeacherUserId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string TeacherFullName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseTypeName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام درس")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int LessonId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string LessonName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "زبان")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int LanguageId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string LanguageName { get; set; }
        //=========================================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        [Display(Name = "وضعيت")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsActive { get; set; } 
        //=========================================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        public string IsActiveName { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات متا")]
        public string MetaDescription { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "اولویت")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public float?  Inx { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "درصد/مبلغ تخفیف")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")] 
        //[Range(0,100,ErrorMessage ="مبلغ تخفیف را درست وارد کنید")]
        public float DiscountPercentOrDiscountAmount  { get; set;  }
         
        //======================================================= 
        /// <summary>
        ///  
        /// </summary>
        [Display(Name = "آیا حالت چند دبیر فعال باشد؟")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsMultiTeacher { get; set; }
        //=========================================================
        /// <summary>
        ///  
        /// </summary>
        public string IsMultiTeacherName { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseCategoryTypeName { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نمایش جزئیات دوره درسایت؟")]
        public ActiveStatus IsShowDetailsInWeb { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "قابل نمایش در سایت ؟")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsVisibleOnSite { get; set; } 
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string IsVisibleOnSiteName { get; set; }
        //=========================================================
        /// <summary>
        /// عنوان
        /// </summary>
        [Display(Name = "مسئول ثبت نام")]
        public string UserEditor { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع تخفیف")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public int DiscountTypeId { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string DiscountType { get; set; }
        //=======================================
        /// <summary>
        /// سوالات دوره
        /// </summary>
        [Display(Name = "سوالات دوره")]
        public List<string> CourseFAQIds { get; set; }
        //=======================================
        /// <summary>
        ///  نظرات دانش اموزان قبلی دوره
        /// </summary>
        [Display(Name = "نظرات دانش اموزان قبلی دوره")]
        public List<string> CommentOldStudentCoursesIds { get; set; }
    }
}
