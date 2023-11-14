using Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.OnlineExamsViewModels
{
    public class OnlineExamsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام آزمون")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "فیلد نا نبایستی بیش از 100 کاراکتر باشد")]
        public string Name { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "تاریخ شروع نبایستی خالی باشد")]
        [RegularExpression(@"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فرمت تاریخ شروع صحیح نمی باشد")]
        public string StartDate { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// ساعت شروع
        /// </summary>
        [Display(Name = "ساعت شروع")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public string StartTime { get; set; }
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
        [Display(Name = "محدودیت زمانی ورود به آزمون")]
        [RegularExpression(pattern: @"^\d+$", ErrorMessage = "فیلد بایستی بصورت عددی باشد")]
        [Range(1, 1000000000, ErrorMessage = "مقدار وارد شده برای زمان، صحیح نمی‌باشد")]
        public int? AllowedTimeToEnter { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public string QuestionTypeName { get; set; }
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
        [Display(Name = "نام معلم")]
        public string TeacherFullName { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public string TeacherUserName { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public string YearName { get; set; }
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
        /// 
        /// </summary>
        public string StartDateTime { get; set; }
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
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "لینک تحلیل آزمون")]
        public string AnalysisVideoLink { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع آزمون")]
        public OnlineExamType OnlineExamType { get; set; }
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
        [Display(Name = "قابل نمایش در سایت ؟")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsVisibleOnSite { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string IsVisibleOnSiteName { get; set; }
    }
}
