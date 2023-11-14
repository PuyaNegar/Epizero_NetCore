using System.ComponentModel.DataAnnotations;
using Common.Enums;

namespace PanelViewModels.ContentsViewModels
{
    public class SlidersViewModel
    {
        //============================================
        /// <summary>
        /// شناسه اسلایدر
        /// </summary>
        public int Id { get; set; }
        //============================================
        /// <summary>
        /// اولویت نمایش
        /// </summary>
        [Display(Name = "اولویت نمایش")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^\d{0,5}$", ErrorMessage = "فیلد بایستی بصورت عددی و حداکثر ۵ رقمی باشد")]
        public int Inx { get; set; }

        //============================================
        /// <summary>
        /// عنوان
        /// </summary>
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(50, ErrorMessage = "عنوان بایستی حداکثر 5۰ کاراکتر باشد")]
        public string Title { get; set; }
        //============================================
        /// <summary>
        /// عنوان جایگزین
        /// </summary>
        [Display(Name = "عنوان جایگزین")]
        [StringLength(50, ErrorMessage = "عنوان جایگزین بایستی حداکثر 5۰ کاراکتر باشد")]
        public string Alt { get; set; }

        //============================================
        /// <summary>
        /// تصویر اسلایدر
        /// </summary>
        [Display(Name = "تصویر اسلایدر")]
        [Required(ErrorMessage = "تصویر نبایستی خالی باشد")]
        public string PicPath { get; set; }

        //============================================
        /// <summary>
        /// لینک URL
        /// </summary>
        [Display(Name = "لینک URL")]
        [StringLength(200, ErrorMessage = "لینک URL بایستی حداکثر 2000 کاراکتر باشد")]
        public string Link { get; set; }
        //=========================================================
        /// <summary>
        /// توضیحات
        /// </summary>
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        //=========================================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }

        //=========================================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        public string IsActiveName { get; set; }
        //=========================================================
    }
}
