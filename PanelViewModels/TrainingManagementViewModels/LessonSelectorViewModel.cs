using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
     public class LessonSelectorViewModel
    {
        /// <summary>
        /// شناسه مقطع تحصیلی
        /// </summary>
        [Display(Name = "مقطع تحصیلی")]
        public int LevelGroupId { get; set; }

        //===========================================================
        /// <summary>
        /// شناسه پایه تحصیلی
        /// </summary>
        [Display(Name = "پایه تحصیلی")]
        public int LevelId { get; set; }

        //===========================================================
        /// <summary>
        /// شناسه درس
        /// </summary>
        [Display(Name = "درس")]
        public int LessonId { get; set; }
    }



}
