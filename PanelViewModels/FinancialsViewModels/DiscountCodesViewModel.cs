using Common.Enums;
using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.FinancialsViewModels
{
    public class DiscountCodesViewModel
    {
        public int Id { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        public string IsActiveName { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "کد")]
        //[Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public string Code { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")] 
        public string Name { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات")]
        //[Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public string Description { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مبلغ/درصدتخفیف")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int AmountOrPercent { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "امکان استفاده در محصولات تخفیف دار")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public ActiveStatus IsUseableForDiscountAcademyProduct { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        public string IsUseableForDiscountAcademyProductName { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "سقف مقدار تخفیف")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int MaxDiscountAmount { get; set; }
        //================================================================
        /// <summary>
        /// تاریخ شروع اعتبار
        /// </summary>
        [Display(Name = "تاریخ شروع اعتبار")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فيلد نبايستی خالی باشد و فرمت تاریخ باید بصورت 1390/01/01 باشد")]
        public string StartDate { get; set; }
        //================================================================
        /// <summary>
        /// تاریخ پایان اعتبار
        /// </summary>
        [Display(Name = "تاریخ پایان اعتبار")]
        [RegularExpression(pattern: @"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فيلد نبايستی خالی باشد و فرمت تاریخ باید بصورت 1390/01/01 باشد")]
        public string EndDate { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع تخفیف")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int DiscountCodeTypeId { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        public string DiscountCodeTypeName { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "همکار فروش")]
        public int? SalePartnerUserId { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        public string SalePartnerUserName { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تعداد استفاده دانش آموز از کد تخفیف")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int NumberOfStudentCanBeUse { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تعداد استفاده کل برای هر کد تخفیف")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int NumberOfTotalUse { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "سهم همکار فروش(مبلغ/درصد)")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int? SalePartnerAmountOrPercent { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع همکاری")]
        public int? SalesPartnerShareTypeId { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        public string SalesPartnerShareTypeName { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تعداد تولید کد تخفیف")]
        public int NumberOfGeneration { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شروع نامگذاری با")]
        public string CodeStartWith { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تعداد حرف")]
        public int CodeRandomCharacter { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "پایان نامگذاری با")]
        public string CodeEndWith { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "سهم از فروش همکار فروش")]
        public ActiveStatus? SalePartnerIsPrepayment { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دوره ها")]
        public List<string> CourseIds { get; set;  }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "جلسات دوره ها")]
        public  List<string>  CourseMeetingIds { get; set;  }
        //================================================================

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "انتخاب دوره")]
        public int? PartnerSaleUserCourseId  { get; set; }
    }
}
