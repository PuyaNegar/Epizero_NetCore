using System.ComponentModel.DataAnnotations;

namespace WebViewModels.FinancialsViewModels
{
    public class OrderPaymentMethodViewModel
    {
        //=================================================================
        /// <summary>
        /// از کیف پول استفاده شود ؟ 
        /// </summary>
        [Required(ErrorMessage = "وضعیت استفاده از کیف پول نبایستی خالی باشد")]
        public bool UseCredit { get; set; }
        //================================================================= 
        /// <summary>
        /// 
        /// </summary>
        public bool UseScore { get; set; }
    }
}
