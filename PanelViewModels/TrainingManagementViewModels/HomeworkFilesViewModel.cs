using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class HomeworkFilesViewModel
    {
        public int Id { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "فایل تکلیف")]
        public string FilePath { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "جلسات دوره")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public int HomeworkId { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "جلسات دوره")]
        public string HomeworkTitle { get; set; }
        //============================================
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        [StringLength(200, ErrorMessage = "نام دوره باید کمتر از {1} کاراکتر باشد")]
        public string Title { get; set; }
    }
}
