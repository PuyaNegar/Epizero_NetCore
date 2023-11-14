using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.ContentsViewModels
{
    public class BlogsViewModel
    {
        //=====================================================
        /// <summary>
        /// شناسه
        /// </summary>
        public int Id { get; set; }
        //=====================================================
        /// <summary>
        /// عنوان
        /// </summary>
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فبلد {0} نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "فیلد نبایستی بیشتر از 100 کاراکتر باشد")]
        public string Title { get; set; }
        //=====================================================
        /// <summary>
        /// متن
        /// </summary>
        [Display(Name = "متن")]
        //[Required(ErrorMessage = "فبلد {0} نبایستی خالی باشد")]
        public string Text { get; set; }
        //=====================================================
        /// <summary>
        /// تصویر
        /// </summary>
        [Display(Name = "تصویر خبر")]
        [Required(ErrorMessage = "تصویر نبایستی خالی باشد")]
        public string PicPath { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public int BlogGroupId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string BlogGroupName { get; set; }
        //=====================================================
    }
}
