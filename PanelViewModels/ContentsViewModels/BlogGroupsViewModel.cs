using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Common.Enums;

namespace PanelViewModels.ContentsViewModels
{
    public class BlogGroupsViewModel
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
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        [StringLength(50, ErrorMessage = "فیلد نبایستی بیشتر از 50 کاراکتر باشد")]
        public string Title { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "وضعیت")]
        public ActiveStatus IsActive { get; set; }
        //=====================================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        public string IsActiveName { get; set; }
        //=====================================================
    }
}
