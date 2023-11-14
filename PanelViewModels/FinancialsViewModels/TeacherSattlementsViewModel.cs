using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.FinancialsViewModels
{
   public class TeacherSattlementsViewModel
    {
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد" )]
        [RegularExpression(@"^\d{4}/\d{2}/\d{2}$")]
        public string Date { get; set;  }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int  SettledAmount { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int TeacherSattlementScheduleId { get; set; }
        //===============================================================
    }
}
