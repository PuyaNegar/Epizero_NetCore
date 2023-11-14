using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.FinancialsViewModels
{
    public class StudentFinancialChequePaymentsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id  { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentFullName  { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ سررسید")]
        public string DueDate { get; set;  }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شرح سند")]
        public string Description  { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شماره چک")]
        //[Required(ErrorMessage = " شماره چک نبایستی خالی باشد")]
        public string ChequeNo  { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مبلغ پرداخت شده (تومان)")]
        [Required(ErrorMessage = "مبلغ پرداخت شده نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int AmountPaid { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "بانک")] 
        public string BankName { get; set; }  
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دانش آموز")]
        [Required(ErrorMessage = "دانش آموز نبایستی خالی باشد")]
        public int StudentUserId  { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ ثبت")] 
        [RegularExpression(@"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فرمت تاریخ بایستی بصورت 1390/05/06 باشد")]
        public string IssueDate  { get; set; }
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
        [Display(Name = "نام دوره")]
        public string CourseName  { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "وضعیت چک")]
        public string ChequesStatusTypeName { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "وضعیت چک")]
        public int ChequesStatusTypeId { get; set; }
        //=========================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentFinancialPaymentId { get; set; }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "چک را انتخاب کنید")]
        [Display(Name = "انتخاب چک")]
        public int PaidChequeId { get; set; }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مبلغ باقیمانده چک (تومان)")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public uint RemainingAmount { get; set;  }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        public string PaidChequeName { get; set; } 
    }
}
