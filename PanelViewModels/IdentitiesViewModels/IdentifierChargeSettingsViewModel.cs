using Common.Enums;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;

namespace PanelViewModels.IdentitiesViewModels
{
    public class IdentifierChargeSettingsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id  { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مبلغ شارژ برای معرف")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int IdentifierChargeAmount { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مبلغ شارژ برای ثبت نام کننده")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int RegisteredUserChargeAmount { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public string IsActiveName { get; set;  }
        //=================================================

    }
}
