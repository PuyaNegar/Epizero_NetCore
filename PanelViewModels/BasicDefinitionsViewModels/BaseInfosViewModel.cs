using Common.Enums;
using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.BasicDefinitionsViewModels
{
    public class BaseInfosViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //================================================
        /// <summary>
        /// هزینه ثابت ارسال سفارش (تومان
        /// </summary>
        [Display(Name = "قیمت هر اپیزرو کوین به تومان")] 
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int EpizeroCoinPrice { get; set; }
        //================================================ 
    }
}
