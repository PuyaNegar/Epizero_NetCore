using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.BaseViewModels
{
  public  class UserViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "انتخاب کاربر")]
        [Required(ErrorMessage = "نام نبایستی خالی باشد")]
        public string StudentFullName { get; set;  }
    }
}
