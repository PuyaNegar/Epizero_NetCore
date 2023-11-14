using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.BaseViewModels
{
   public class UniversityViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام دانشگاه ")]
        [Required(ErrorMessage = "نام فروشگاه نبایستی خالی باشد")]
        public string UniversityName { get; set; }
    }
}
