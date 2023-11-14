using Common.Enums;
using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System; 
using System.ComponentModel.DataAnnotations; 

namespace PanelViewModels.FinancialsViewModels
{
   public class TeacherSattlementSchedulesViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ تسویه")]
        [Required(ErrorMessage = "تاریخ تسویه نبایستی خالی باشد")]
        [RegularExpression(@"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فرمت تاریخ تسویه صحیح نمی باشد")]
        public string Date { get; set; } 
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تسویه؟")]
        public bool IsSettled { get; set; }
        //============================================================ 
        /// <summary>
        /// 
        /// </summary> 
        [JsonConverter(typeof(CurrencyBigIntegerConvertor))]
        public long SettledAmount { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary
        [Display(Name = "نحوه پرداخت ")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int TeacherPaymentMethodId { get; set; }

    }
}
