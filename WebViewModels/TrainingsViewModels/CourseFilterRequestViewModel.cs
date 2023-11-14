using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebViewModels.TrainingsViewModels
{
    public class CourseFilterRequestViewModel
    {
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int LevelGroupId { get; set;  }
        //============================================
    }
}
