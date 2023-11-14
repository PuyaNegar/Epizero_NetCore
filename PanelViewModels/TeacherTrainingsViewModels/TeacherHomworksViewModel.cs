using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TeacherTrainingsViewModels
{
   public class TeacherHomworksViewModel
    {
        public int Id { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "عنوان تکلیف")]
        [StringLength(100, ErrorMessage = "فیلد نبایستی بیش از 100 کاراکتر باشد")]
        public string Title { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "فایل تکلیف")]
        [Required(ErrorMessage = "فایل تکلیف نبایستی خالی باشد")]
        public string FilePath { get; set; }
        //============================================================
        /// <summary>
        /// تاریخ انتشار
        /// </summary>
        [Display(Name = "تاریخ انتشار")]
        [RegularExpression(@"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فرمت تاریخ صحیح نمی باشد.")]
        public string RegDateTime { get; set; }
        //============================================================
        /// <summary>
        /// وضعیت کاربر
        /// </summary>
        [Display(Name = "وضعیت ")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }
        //============================================================

    }
}
