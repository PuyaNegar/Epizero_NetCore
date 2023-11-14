using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.FinancialsViewModels
{
    public class AddSalesPartnerUserSharesViewModel
    {
        /// <summary>
        /// 
        /// </summary> 
        [Display(Name = "سهم همکار فروش (تومان)")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int Amount  { get; set; }
    }
}
