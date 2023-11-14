using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using WebViewModels.UtilityJsonConvertor;

namespace WebViewModels.FinancialsViewModels
{
    public class CreditPaymentMethodViewModel
    {
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        //[Range(1000, 100000000, ErrorMessage = "مبلغ وارده بایستی مابین هزار تا صد میلیون تومان باشد")]
        [Required(ErrorMessage = "مبلغ نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int TotalAmount { get; set; }
        //=====================================================
    }
}
