using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class AbsentationsViewModel
    {
        public int Id { get; set; }
        //==========================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام جلسه")]
        public string CourseMeetingName { get; set; }
        //==========================================================================
        /// <summary>
        /// شناسه برنامه هفتگی 
        /// </summary>
        [Display(Name = "شناسه جلسه")]
        [Required(ErrorMessage = "شناسه جلسه نبایستی خالی باشد")]
        public int? CourseMeetingId { get; set; }
        //==========================================================================
        /// <summary>
        /// 
        /// </summary>
        public ActiveStatus IsAbsentationsDone { get; set; }
        //==========================================================================
        /// <summary>
        /// تاریخ
        /// </summary>
        [Display(Name = "تاریخ")]
        [RegularExpression(@"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فرمت تاریخ صحیح نمی باشد")]
        public string Date { get; set; }
        //==========================================================================
        /// <summary>
        /// تعداد حاظرین
        /// </summary>
        [Display(Name = "تعداد حاظرین")]
        public int IsPresentCount { get; set; }
        //==========================================================================
        /// <summary>
        /// تعداد  کل دانش آموزان
        /// </summary>
        [Display(Name = "تعداد کل دانش آموزان")]
        public int CountStudent { get; set; }
        //==========================================================================
        /// <summary>
        /// لیست وضعیت حضور غیاب شده دانش آموزان 
        /// </summary> 
        public List<StudentsAbsentationStateViewModel> StudentsAbsentationState { get; set; }
        //==========================================================================
    }
}
