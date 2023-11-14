using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.OnlineExamsViewModels
{
     public class LessonTopicSelectorViewModel
    {
        /// <summary>
        /// شناسه مقطع تحصیلی  
        /// </summary>
        [Display(Name = "مقطع تحصیلی")]
        public int LevelId { get; set; }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// شناسه درس
        /// </summary>
        [Display(Name = "درس")]
        public int LessonId { get; set; }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// شناسه سرفصل
        /// </summary>
        [Display(Name = "سرفصل")]
        public int LessonTopicId { get; set; }
    }



}
