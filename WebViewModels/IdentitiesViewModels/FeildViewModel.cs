using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebViewModels.IdentitiesViewModels
{
   public class SelectedFeildViewModel
    {
        [Display(Name = "رشته")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public int FieldId { get; set; }
    }
}
