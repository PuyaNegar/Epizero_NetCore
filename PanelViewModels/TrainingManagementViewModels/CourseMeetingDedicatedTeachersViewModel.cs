using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
    public class CourseMeetingDedicatedTeachersViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id  { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شناسه جلسه")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int CourseMeetingId { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دبیر")]
        [Required(ErrorMessage = "دبیر زا انتخاب کنید ...")]
        public int TeacherUserId { get; set; }
        //==============================================
    }
}
