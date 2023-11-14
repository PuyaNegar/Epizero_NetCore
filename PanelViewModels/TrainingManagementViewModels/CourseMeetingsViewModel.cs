using Common.Enums;
using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class CourseMeetingsViewModel
    {
        public int Id { get; set; }
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
        /// فعال یا غیرفعال
        /// </summary>
        [Display(Name = "قابل خرید است ؟")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsPurchasable { get; set; }

        //=========================================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        public string IsPurchasableName { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دوره")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public int CourseId { get; set; }
        //=========================================================
        /// <summary>
        /// دوره
        /// </summary>
        public string CourseName { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "جلسه دوره")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "نام دوره باید کمتر از {1} کاراکتر باشد")]
        public string Name { get; set; }
        //=====================================================
        ///// <summary>
        ///// 
        ///// </summary>
        //[Display(Name = "استاد")]
        //[Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        //public int TeacherUserId { get; set; }
        //=====================================================
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int Price { get; set; }
        //===================================================== 
        /// <summary>
        /// درصد تخفیف
        /// </summary>
        //[Display(Name = "قیمت با تخفیف")]
        ////[Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        //[JsonConverter(typeof(CurrencyIntegerConvertor))]
        //public int DiscountPrice { get; set; }
        //===================================================== 
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد و فرمت تاریخ باید بصورت 1390/01/01 باشد")]
        [RegularExpression(pattern: @"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فيلد نبايستی خالی باشد و فرمت تاریخ باید بصورت 1390/01/01 باشد")]
        public string StartDate { get; set; }
        //===================================================== 
        /// <summary>
        ///  
        /// </summary>
        [Display(Name = "ساعت شروع")]
        //[Required(ErrorMessage = "فيلد نبايستی خالی باشد و فرمت ساعت باید بصورت ۱۲:۰۰ باشد")]
        [RegularExpression(pattern: @"^\d{2}:\d{2}$", ErrorMessage = "فيلد نبايستی خالی باشد و فرمت ساعت باید بصورت ۱۲:۰۰ باشد")]
        public string StartTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "درصد/مبلغ تخفیف")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        //[Range(0, 100, ErrorMessage = "مبلغ تخفیف را درست وارد کنید")]
        public float DiscountPercentOrDiscountAmount { get; set;  }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public ActiveStatus IsMultiTeacher { get; set; }
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
        public string DiscountType { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع تخفیف")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public int DiscountTypeId { get; set; }
        //=========================================================
    }
}
