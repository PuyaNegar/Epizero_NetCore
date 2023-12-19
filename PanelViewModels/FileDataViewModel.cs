using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace PanelViewModels
{
    public class FileDataViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "فایل اکسل")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public string FileData { get; set; }
    }

}
