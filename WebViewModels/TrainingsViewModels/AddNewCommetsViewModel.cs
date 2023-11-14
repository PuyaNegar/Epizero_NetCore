using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebViewModels.TrainingsViewModels
{
    public class AddNewCommetsViewModel
    {
        /// <summary>
        /// متن نظر
        /// </summary>
        [Display(Name ="متن نظر")]
        [Required(ErrorMessage = "فیلد {0} نبايستی خالی باشد")]
        public string Comment { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// امتیاز
        /// </summary>
        [Display(Name = "امتیاز")]
        public decimal? Rate { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// شناسه دوره
        /// </summary>
        [Display(Name = "شناسه دوره")]
        [Required(ErrorMessage = "فیلد {0} نبايستی خالی باشد")]
        public int CourseId { get; set; }
 
    }
}
