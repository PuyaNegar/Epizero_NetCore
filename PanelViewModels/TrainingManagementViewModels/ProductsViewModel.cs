using Common.Enums;
using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class ProductsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام دوره")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "نام دوره باید کمتر از {1} کاراکتر باشد")]
        public string Name { get; set; }
        //=====================================================
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int Price { get; set; }
        //===================================================== 
        /// <summary>
        /// درصد تخفیف
        /// </summary>
        [Display(Name = "مبلغ تخفیف")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int DiscountPrice { get; set; }
        //===================================================== 
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
        [Display(Name = "نوع محصول")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public int ProductTypeId { get; set; }
        //=========================================================
        /// <summary>
        /// دوره
        /// </summary>
        public string ProductTypeName { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تصویر")]
        public string PicPath { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "فایل")]
        public string FilePath { get; set; }
        //===================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
    }
}
