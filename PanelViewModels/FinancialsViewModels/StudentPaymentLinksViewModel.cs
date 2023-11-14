using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.FinancialsViewModels
{
    public class StudentPaymentLinksViewModel
    {
        //================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مبلغ قابل پرداخت")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int AmountPayable { get; set;  }
        //================================================
    }
}
