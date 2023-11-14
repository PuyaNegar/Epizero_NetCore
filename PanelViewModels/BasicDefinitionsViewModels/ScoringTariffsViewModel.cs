using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace PanelViewModels.BasicDefinitionsViewModels
{
    public class ScoringTariffsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //*******************************************************************
        /// <summary>
        /// اولویت
        /// </summary>
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        [Display(Name = "میزان اپیزرو کوین")]
        public int Score { get; set; }
        //*******************************************************************
        /// <summary>
        /// عنوان
        /// </summary> 
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        //*******************************************************************  
    }
}
