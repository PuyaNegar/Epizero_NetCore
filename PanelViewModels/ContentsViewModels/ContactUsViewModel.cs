using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.ContentsViewModels
{
   public class ContactUsViewModel
    {
        [Display(Name = "دوره")]
        public string CourseName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام نام خانوادگی")]
        public string FullName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شماره موبایل")]
        public string MobNo { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات")]
        [StringLength(300)]
        public string Description { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "بررسی شده ؟")]
        public ActiveStatus IsRead { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string IsReadName { get; set; }
        //=====================================================
         
        /// <summary>
        /// 
        /// </summary>
        public string RegDateTime { get; set; }
    }
}
