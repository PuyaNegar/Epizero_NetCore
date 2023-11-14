using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class ProductTypesViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع محصول")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "نام گروه باید کمتر از {1} کاراکتر باشد")]
        public string Name { get; set; }
    }
}
