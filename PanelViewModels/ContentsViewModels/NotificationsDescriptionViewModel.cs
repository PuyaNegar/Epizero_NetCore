﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.ContentsViewModels
{
  public  class NotificationsDescriptionViewModel
    {
        /// <summary>
        /// 
        /// </summary> 
        [Required]
        public int Id { get; set; }
        //===================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
    }
}
