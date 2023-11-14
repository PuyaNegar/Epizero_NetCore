using System;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.BaseViewModels
{
    public class IntegerIdentifierViewModel
    {
        /// <summary>
        /// شناسه
        /// </summary>
        [Required(ErrorMessage = "شناسه نبایستی خالی باشد")]
        public int? Id { get; set;  }
    }
}
