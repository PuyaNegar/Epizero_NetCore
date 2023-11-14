using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class HomeworkAnswersViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
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
        /// 
        /// </summary>
        [Display(Name = "تکالیف")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public int HomeworkId { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تکالیف")]
        public string HomeworkName { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دانش آموز")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public int StudentUserId { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دانش آموز")]
        public string StudentUserName { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نمره")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public float? Grade { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نمره")]
        public string GradeName { get; set; }
    }
}
