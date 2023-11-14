using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.BaseViewModels
{
    public class CourseViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "انتخاب دوره / آزمون")]
        [Required(ErrorMessage = "نام نبایستی خالی باشد")]
        public string CourseName { get; set; }
    }
}
