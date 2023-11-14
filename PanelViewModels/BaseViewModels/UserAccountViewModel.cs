using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.BaseViewModels
{
  public  class UserAccountViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "نام کاربری نبایستی خالی باشد")]
        public string Username { get; set;  }
    }
}
