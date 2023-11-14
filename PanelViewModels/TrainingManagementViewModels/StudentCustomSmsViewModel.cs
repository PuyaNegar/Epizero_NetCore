using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
    public class StudentCustomSmsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public int CourseId { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public string Message { get; set; }
    }
}
