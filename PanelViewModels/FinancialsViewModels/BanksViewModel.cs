using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.FinancialsViewModels
{
    public class BanksViewModel
    {
        //======================================================================
        /// <summary>
        /// شناسه بانک
        /// </summary>
        public int Id { get; set; }
        //======================================================================
        /// <summary>
        /// نام بانک
        /// </summary>
        [Display(Name = "نام بانک")]
        [Required(ErrorMessage = "نام بانک را وارد کنید")]
        [StringLength(100, ErrorMessage = "نام بانک باید کمتر از {1} کاراکتر باشد")]
        public string Name { get; set; }
        //======================================================================
    }
}
