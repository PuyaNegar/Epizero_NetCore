using Common.Enums;
using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.FinancialsViewModels
{
    public class ChangeCreditViewModel
    {
        //============================================================
        /// <summary>
        /// شناسه مشتری
        /// </summary>
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int StudentUserId { get; set; }
        //============================================================
        /// <summary>
        /// موجودی
        /// </summary>
        [Display(Name = "موجودی فعلی")] 
        public int Balance { get; set; }
        //============================================================
        /// <summary>
        /// نوع عملیات، افزایش یا کاهش 
        /// </summary>
        [Display(Name = "نوع عملیات")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public QuantityControl QuantityControl { get; set; }
        //============================================================
        /// <summary>
        /// مبلغ افزایش یا کاهش 
        /// </summary>
        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int Amount { get; set; }
        //============================================================
        /// <summary>
        /// توضیحات
        /// </summary>
        [Display(Name = "توضیحات")]
        [StringLength(200 , ErrorMessage = "توضیحات نبایستی بیش از 200 کاراکتر باشد")]
        public string Comment { get; set; }
        //============================================================
    }
}
