using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.IdentitiesViewModels
{
    public class SendSMSTargetsViewModel
    {
        //========================================================================
        /// <summary>
        /// شناسه
        /// </summary>
        public int Id { get; set; }
        //========================================================================
        /// <summary>
        /// عنوان
        /// </summary>
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(50, ErrorMessage = "عنوان بایستی 50 کاراکتر باشد")]
        public string Title { get; set; }
        //========================================================================
        //========================================================================
        /// <summary>
        /// شماره موبایل
        /// </summary>
        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^(09\d{9})$", ErrorMessage = "شماره موبایل بایستی بصورت عددی و با فرمت 09000000000 باشد")]
        public string MobNo { get; set; }
        //========================================================================
        /// <summary>
        /// وضعیت فعال بودن
        /// </summary>
        [Display(Name = "وضعیت فعال بودن")]
        public ActiveStatus IsActive { get; set; }
        //========================================================================
        /// <summary>
        /// وضعیت فعال بودن
        /// </summary>
        [Display(Name = "وضعیت فعال بودن")]
        public string IsActiveName { get; set; }
        //======================================================================== 
    }
}
