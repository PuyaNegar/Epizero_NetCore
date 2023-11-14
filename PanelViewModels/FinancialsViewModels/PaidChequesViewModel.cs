using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.FinancialsViewModels
{
    public class PaidChequesViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=========================================== 
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "تاریخ سررسید نبایستی خالی باشد")]
        [RegularExpression(@"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فرمت تاریخ بایستی بصورت 1390/05/06 باشد")]
        [Display(Name = "تاریخ سررسید")]
        public string DueDate { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شرح سند")]
        public string Description { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شماره چک")]
        [Required(ErrorMessage = " شماره چک نبایستی خالی باشد")]
        public string ChequeNo { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مبلغ چک (تومان)")]
        [Required(ErrorMessage = "مبلغ پرداخت شده نبایستی خالی باشد")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int AmountPaid { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "بانک")]
        public string BankName { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "بانک")]
        [Required(ErrorMessage = "بانک نبایستی خالی باشد")]
        public int BankId { get; set; }
        //===================================================
        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = " تاریخ ثبت نبایستی خالی باشد")]
        [RegularExpression(@"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فرمت تاریخ بایستی بصورت 1390/05/06 باشد")]
        public string IssueDate { get; set; }
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
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        public int ChequesStatusTypeId { get; set; }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "باقیمانده مبلغ (تومان)")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int RemainingAmount { get; set; }
        //=====================================================================


        //========================================
        //
        /// <summary>
        /// کد شعبه
        /// </summary>
        [Display(Name = "کد شعبه")]
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        public string BranchCode { get; set; }
        //========================================  
        /// <summary>
        /// نام شعبه
        /// </summary>
        [Display(Name = "نام شعبه")]
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        public string BranchName { get; set; }
        //========================================
        /// <summary>
        /// کد صیادی 16 رقمی
        /// </summary>
        [Display(Name = "کد صیادی 16 رقمی")]
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        [RegularExpression(pattern: @"^\d{16}$", ErrorMessage = "فیلد بایستی بصورت عددی و حداکثر 16 رقمی باشد")]
        public string FishingCode { get; set; }
        //========================================
        /// <summary>
        /// شماره حساب
        /// </summary>
        [Display(Name = "شماره حساب")]
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        public string AccountNumber { get; set; }
        //========================================
        /// <summary>
        /// نام صاحب حساب
        /// </summary>
        [Display(Name = "نام صاحب حساب")]
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        public string NameAccountHolder { get; set; }
        //========================================
    }
}
