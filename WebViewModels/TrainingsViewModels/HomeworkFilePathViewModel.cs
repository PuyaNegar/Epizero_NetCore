using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebViewModels.TrainingsViewModels
{
    public class HomeworkFilePathViewModel
    {
        [Display(Name = "شناسه تکلیف")]
        [Required(ErrorMessage = "شناسه تکلیف نبایستی خالی باشد")]
        public int HomeWorkId { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "فایل تکلیف")]
        [Required(ErrorMessage = "فایل تکلیف نبایستی خالی باشد")]
        public string FilePath { get; set; }
    }
}
