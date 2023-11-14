using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebViewModels.IdentitiesViewModels
{
    public class ConfirmationCodesViewModel
    {
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "شناسه ارسالی نا معتبر است")]
        public string HashId { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "نام کاربری وارد نشده است")]
        public string UserName { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public int RemainingTimeToExpire { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public string ConfirmCode { get;  set;  }
        //============================================================
    }
}
