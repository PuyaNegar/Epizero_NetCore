using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WebViewModels.IdentitiesViewModels
{
    public class LoginedUserInformationDTOModel
    {
        //===============================================================================
        /// <summary>
        /// نام کاربر 
        /// </summary>
        public string UserFullName { get; set; }
        //===============================================================================
        /// <summary>
        /// نام کاربری 
        /// </summary>
        public string UserName { get; set; }
        //===============================================================================
        /// <summary>
        /// تاریخ انقضا توکن 
        /// </summary>
        //public string TokenExpireDateTime { get; set;  }
        //===============================================================================
        /// <summary>
        ///  توکن ایجاد شده 
        /// </summary>
        public string Token { get; set; }
        //===============================================================================
        /// <summary>
        /// شناسه مشتری
        /// </summary>
        [JsonIgnore]
        public int CustomerId { get; set; }
    }
}
