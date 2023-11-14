﻿using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace TeacherViewModels.TraningsViewModels
{
    public class TeacherCourseMeetingBookletsViewModel
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
        ///    فایل
        /// </summary>
        [Display(Name = "فایل")]
        [Required(ErrorMessage = "فایل نبایستی خالی باشد")]
        public string FilePath { get; set; }
        //============================================

        /// <summary>
        /// توضیحات
        /// </summary>
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public string Description { get; set; }
        //============================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }
        //============================================
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
        public string CourseMeetingName { get; set; }

    }
}
