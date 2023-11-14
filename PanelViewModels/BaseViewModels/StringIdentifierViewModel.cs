using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.BaseViewModels
{
    public  class StringIdentifierViewModel
    {
        /// <summary>
        /// شناسه
        /// </summary>
        [Required(ErrorMessage = "شناسه نبایستی خالی باشد")]
        public string Id { get; set; }
    }
}
