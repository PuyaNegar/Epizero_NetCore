using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebViewModels.TrainingsViewModels
{
    public class BookFilterRequestViewModel
    {
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int courseTypeId { get; set;  }
        //============================================
    }
}
