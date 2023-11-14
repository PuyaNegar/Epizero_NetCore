using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebViewModels.OrdersViewModel
{
    public class DiscountCodeViewModel
    { 
        /// <summary>
        ///کوپن
        /// </summary>
        [Required(ErrorMessage = "کد تخفیف نبایستی خالی باشد")]
        public string Code { get; set; }
        //=========================================================
    }
}
