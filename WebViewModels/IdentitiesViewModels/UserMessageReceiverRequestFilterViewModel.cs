using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebViewModels.IdentitiesViewModels
{
   public class UserMessageReceiverRequestFilterViewModel
    {
        /// <summary>
        /// 
        /// </summary>
       // [Required(ErrorMessage = "تاریخ شروع نبایستی خالی باشد")]
        public string StartDate { get; set; }
        //=========================================

        /// <summary>
        /// 
        /// </summary>
     //   [Required(ErrorMessage = "تاریخ پایان نبایستی خالی باشد")]
        public string EndDate { get; set; }
        //========================================
        /// <summary>
        /// 
        /// </summary>
 
        public List<string> TagIds { get; set; }
    }
}
