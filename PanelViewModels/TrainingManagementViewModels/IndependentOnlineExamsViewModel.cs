using Common.Enums;
using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class IndependentOnlineExamsViewModel
    {
        public int Id { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        [Display(Name = "وضعيت")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        public string IsActiveName { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        [Display(Name = "قابل خرید است ؟")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsPurchasable { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public ActiveStatus IsMultiTeacher { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        public string IsPurchasableName { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دوره")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public int CourseId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==
        /// <summary>
        /// دوره
        /// </summary>
        public string CourseName { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام آزمون")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "نام آزمون باید کمتر از {1} کاراکتر باشد")]
        public string Name { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int Price { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد و فرمت تاریخ باید بصورت 1390/01/01 باشد")]
        [RegularExpression(pattern: @"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فيلد نبايستی خالی باشد و فرمت تاریخ باید بصورت 1390/01/01 باشد")]
        public string StartDate { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        ///  
        /// </summary>
        [Display(Name = "ساعت شروع")]
        //[Required(ErrorMessage = "فيلد نبايستی خالی باشد و فرمت ساعت باید بصورت ۱۲:۰۰ باشد")]
        [RegularExpression(pattern: @"^\d{2}:\d{2}$", ErrorMessage = "فيلد نبايستی خالی باشد و فرمت ساعت باید بصورت ۱۲:۰۰ باشد")]
        public string StartTime { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "درصد/مبلغ تخفیف")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
       // [Range(0, 100, ErrorMessage = "مبلغ تخفیف را درست وارد کنید")]
        public float DiscountPercentOrDiscountAmount { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع سوالات آزمون ")]
        [Required(ErrorMessage = " نوع سوالات آزمون نبایستی خالی باشد")]
        public int QuestionTypeId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public string QuestionTypeName { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "محدودیت زمانی ورود به آزمون")]
        [RegularExpression(pattern: @"^\d+$", ErrorMessage = "فیلد بایستی بصورت عددی باشد")]
        [Range(1, 1000000000, ErrorMessage = "مقدار وارد شده برای زمان، صحیح نمی‌باشد")]
        public int? AllowedTimeToEnter { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام معلم")]
        [Required(ErrorMessage = " نام معلم  نبایستی خالی باشد")]
        public int? TeacherUserId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public string TeacherUserName { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مدت زمان آزمون (دقیقه)")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^\d+$", ErrorMessage = "فیلد بایستی بصورت عددی باشد")]
        [Range(1, 1000000000, ErrorMessage = "مقدار وارد شده برای زمان، صحیح نمی‌باشد")]
        public int Duration { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// سوالات آزمون برای دانشجویان تصادفی باشد؟
        /// </summary>
        [Display(Name = "سوالات آزمون تصادفی باشد؟")]
        public ActiveStatus IsRandomQuestions { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// سوالات آزمون برای دانشجویان تصادفی باشد؟
        /// </summary>
        public string IsRandomQuestionsName { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// گزینه های تستی در سوالات برای دانشجویان تصادفی باشد؟
        /// </summary>
        [Display(Name = "گزینه ها در سوالات برای دانشجویان تصادفی باشد؟")]
        public ActiveStatus IsRandomOption { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        /// گزینه های تستی در سوالات برای دانشجویان تصادفی باشد؟
        public string IsRandomOptionName { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// آزمون نمره منفی دارد؟
        /// </summary>
        [Display(Name = "آزمون نمره منفی دارد؟")]
        public ActiveStatus HasNegativePoint { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// آزمون نمره منفی دارد؟
        /// </summary>
        public string HasNegativePointName { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نمره از چند")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^\d+$", ErrorMessage = "فیلد بایستی بصورت عددی باشد")]
        [Range(5, 100, ErrorMessage = "مقدار وارد شده برای نمره، صحیح نمی‌باشد")]
        public int MaxGrade { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public int OnlineExamId  { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "لینک تحلیل آزمون")]
        public string AnalysisVideoLink { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "امکان ورود به آزمون منقضی شده؟")]
        public ActiveStatus IsAbleToEnterExpiredExam { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "امکان ورود به آزمون منقضی شده؟")]
        public string IsAbleToEnterExpiredExamName { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "آیا آزمون قابلیت اتصال به رشته های خاص را دارد؟")]
        public ActiveStatus IsAvailableForSpecificFields { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "رشته ها")]
        public List<string> OnlineExamFieldIds { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public string DiscountType { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع تخفیف")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public int DiscountTypeId { get; set; }
        //=========================================================
    }
}
