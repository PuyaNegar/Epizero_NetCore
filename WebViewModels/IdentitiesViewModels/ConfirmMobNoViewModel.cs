using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebViewModels.IdentitiesViewModels
{
    public class ConfirmMobNoViewModel
    {
        //===================================================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "شماره موبایل نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^0\d{10}$", ErrorMessage = "فرمت شماره موبایل صحیح وارد وارد شود بطور مثال 09149876543.")]
        public string UserName { get; set;  }
        //===================================================================================
    }
}
