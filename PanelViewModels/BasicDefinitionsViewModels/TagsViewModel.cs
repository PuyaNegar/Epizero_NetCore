using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.BasicDefinitionsViewModels
{
   public class TagsViewModel
    {
        /// <summary>
        /// شناسه تگ
        /// </summary>
        public int Id { get; set; }
        //=========================================================

        /// <summary>
        /// عنوان
        /// </summary>
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(80, ErrorMessage = " عنوان  بایستی حداکثر 80 کاراکتر باشد ")]
        [RegularExpression(@"^((?!–).)*|((?!-).)*$", ErrorMessage = "مجاز به استفاده از خط تیره نمی‌باشید")]
        public string Title { get; set; }
        //=========================================================
    }
}
