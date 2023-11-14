﻿using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class CourseMeetingVideosViewModel
    {
        /// <summary>
        /// شناسه  
        /// </summary>
        public int Id { get; set; }
        //============================================
        /// <summary>
        /// عنوان
        /// </summary>
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "عنوان بایستی حداکثر 100 کاراکتر باشد")]
        public string Title { get; set; }
        //============================================
        /// <summary>
        ///    تصویر
        /// </summary>
        [Display(Name = "تصویر")]
        public string BannerPicPath { get; set; }
        //============================================
        /// <summary>
        /// لینک URL
        /// </summary>
        [Display(Name = "لینک URL")]
  
        public string Link { get; set; }
        //============================================
        /// <summary>
        /// توضیحات
        /// </summary>
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        //============================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }

        //============================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        public string IsActiveName { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "جلسات دوره")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public int CourseMeetingId { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "جلسات دوره")]
        public string CourseMeetingName{ get; set; }
        //============================================ 
        /// <summary>
        /// عنوان
        /// </summary>
        [Display(Name = "مسئول ثبت نام")]
        public string UserEditor { get; set; }
    }
}
