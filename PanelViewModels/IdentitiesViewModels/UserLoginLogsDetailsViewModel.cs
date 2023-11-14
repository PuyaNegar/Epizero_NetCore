using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.IdentitiesViewModels
{
   public class UserLoginLogsDetailsViewModel
    {
        public long Id { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام نام خانوادگی")]
        public string StudentUserFullName { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "آی پی")]
        public string Ip { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "اطلاعات مرورگر")]
        public string UserAgent { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "کد ورود")]
        public string Guid { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ ورود")]
        public string RegDateTime { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تعداد ورود")]
        public string LoginCount { get; set; }
    }
}
