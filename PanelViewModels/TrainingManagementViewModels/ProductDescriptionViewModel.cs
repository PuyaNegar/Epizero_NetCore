using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class ProductDescriptionViewModel
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
        //===================================================================
    }
}
