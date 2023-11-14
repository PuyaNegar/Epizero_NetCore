using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.FinancialsViewModels
{
    public class AddStudentFinancialPaymentsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "درخواست شماره ارجاع")]
        public string RequestReferenceNumber { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مبلغ پرداخت شده")]
        [Required(ErrorMessage = "مبلغ پرداخت شده نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int AmountPaid { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دانش آموز")]
        [Required(ErrorMessage = "دانش آموز نبایستی خالی باشد")]
        public int StudentUserId { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شرح سند")]
        public string Description { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نحوه پرداخت")]
        [Required(ErrorMessage = " نحوه پرداخت نبایستی خالی باشد")]
        public int StudentFinancialPaymentTypeId { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = " تاریخ ثبت نبایستی خالی باشد")]
        [RegularExpression(@"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فرمت تاریخ بایستی بصورت 1390/05/06 باشد")]
        public string RegDateTime { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دوره")]
        [Required(ErrorMessage = "جلسه نبایستی خالی باشد")]
        public int CourseMeetingStudentId { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع پرداخت")]
        public int PaymentTypeId { get; set; } 
    }
}
