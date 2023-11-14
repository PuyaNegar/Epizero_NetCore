using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class FieldsViewModel
    {
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //============================================
        /// <summary>
        /// نام رشته
        /// </summary>
        [Required(ErrorMessage = "نام رشته را وارد کنید")]
        [StringLength(100, ErrorMessage = "نام زنگ باید کمتر از {1} کاراکتر باشد")]
        public string Name { get; set; }
    }
}
