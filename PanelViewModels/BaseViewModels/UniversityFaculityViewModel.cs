using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.BaseViewModels
{
   public class UniversityFaculityViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام دانشکده ")]
        [Required(ErrorMessage = "نام دانشکده نبایستی خالی باشد")]
        public string UniversityFaculityName { get; set; }
    }
}
