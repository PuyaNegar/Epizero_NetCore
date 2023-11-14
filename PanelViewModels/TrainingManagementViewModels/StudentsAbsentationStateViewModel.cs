using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
  public  class StudentsAbsentationStateViewModel
    {
        //==========================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شناسه دانش آموزان")]
        [Required(ErrorMessage = "شناسه دانش آموزان نبایستی خالی باشد")]
        public int? StudentUserId { get; set; }
        //==========================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "وضعیت حضور")]
        public bool? IsPresent { get; set; }
        //==========================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام دانش آموز")]
        public string StudentFullName { get; set; }
        //==========================================================================
    }
}
