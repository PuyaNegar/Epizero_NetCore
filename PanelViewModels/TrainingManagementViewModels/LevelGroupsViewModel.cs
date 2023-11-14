using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace PanelViewModels.TrainingManagementViewModels
{
    public class LevelGroupsViewModel
    {
        public int Id { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "نام باید کمتر از {1} کاراکتر باشد")]
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات")]
        
  
        public string Description { get; set; }
    }
}
