using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebViewModels.ContentsViewModels
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
        public string PicPath { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string RegDateTime { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دسته بندی")]
        public int BlogGroupId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دسته بندی")]
        public string BlogGroupName { get; set; }
        //=====================================================
        
    }
}
