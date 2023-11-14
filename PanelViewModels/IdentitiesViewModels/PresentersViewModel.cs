using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.IdentitiesViewModels
{
   public class PresentersViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(200, ErrorMessage = "نام بایستی حداکثر 20۰ کاراکتر باشد")]
        public string FirstName { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(200, ErrorMessage = "نام خانوادگی بایستی حداکثر 20۰ کاراکتر باشد")]
        public string LastName { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "کد")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(50, ErrorMessage = "کد بایستی حداکثر 50 کاراکتر باشد")]
        public string Code { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string IsActiveName { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "درصد کمسیون")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [Range(1, 100, ErrorMessage = "مقدار وارد شده معتبر نمی‌باشد")]
        public int CommissionPercent { get; set; }
    }
}
