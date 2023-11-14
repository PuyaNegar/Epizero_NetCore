using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class HomeworksViewModel
    {
        public int Id { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(200, ErrorMessage = "عنوان باید کمتر از {1} کاراکتر باشد")]
        public string Title { get; set; }
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
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        [Display(Name = "تاریخ منقضی ")]
        public string ExpiredDate { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ ثبت")]
        public string RegDateTime { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "فایل تکلیف")]
        public string FilePath { get; set; }
        //============================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        [Display(Name = "وضعيت")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }
        //============================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        public string IsActiveName { get; set; }


    }
}
