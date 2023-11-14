using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.ContentsViewModels
{
   public class ProductPromosViewModel
    {
        //=================================================
        /// <summary>
        /// شناسه محصول سکشن تبلیغاتی
        /// </summary>
        public int Id { get; set; }

        //=================================================
        /// <summary>
        /// شناسه محصول
        /// </summary>
        [Display(Name = "نام محصول")]
        public int ProductId { get; set; }
        //==================================================
        /// <summary>
        /// دانش آموز
        /// </summary>
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public string ProductIds { get; set; }
        //==================================================
        /// <summary>
        /// نام  
        /// </summary>
        public string ProductName { get; set; }

        //==================================================
        /// <summary>
        /// شناسه سکشن تبلیغاتی
        /// </summary>
        [Display(Name = "سکشن تبلیغاتی")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int ProductPromoSectionGroupId { get; set; }

        //==================================================
        /// <summary>
        /// سکشن تبلیغاتی
        /// </summary>
        public string ProductPromoSectionGroupName { get; set; }

        //==================================================
        /// <summary>
        /// اولویت نمایش
        /// </summary>
        [Display(Name = "اولویت نمایش")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^\d{0,5}$", ErrorMessage = "فیلد بایستی بصورت عددی و حداکثر 5 رقمی باشد")]
        public int Inx { get; set; }
    }
}
