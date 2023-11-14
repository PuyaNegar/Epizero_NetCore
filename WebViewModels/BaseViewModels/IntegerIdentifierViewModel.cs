using System.ComponentModel.DataAnnotations;

namespace WebViewModels.BaseViewModels
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
