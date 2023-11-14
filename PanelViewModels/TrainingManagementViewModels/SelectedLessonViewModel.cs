using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class SelectedLessonViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام درس")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int LessonId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string LessonName { get; set; }
        //=====================================================
    }
}
