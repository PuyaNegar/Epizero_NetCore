using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using WebViewModels.UtilityJsonConvertor;

namespace WebViewModels.IdentitiesViewModels
{
    public class IncreaseSmsCreditViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        [Required(ErrorMessage = "مبلغ شارژ پیامک نبایستی خالی باشد")] 
        public int Amount { get; set;  } 
    }
}
