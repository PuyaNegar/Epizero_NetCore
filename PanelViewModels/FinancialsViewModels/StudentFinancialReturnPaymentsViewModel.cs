
using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.FinancialsViewModels
{
    public class StudentFinancialReturnPaymentsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شرح سند")]
        public string Description { get; set; } 
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مبلغ عودتی (تومان)")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int ReturnAmount { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نحوه عودت")]
        public int ReturnPaymentTypeId { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نحوه عودت")]
        public string ReturnPaymentTypeName { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentUserFullName { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string AmountPaidDateTime { get; set;  }
        //===================================================
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
        public string CourseName  { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public string UserEditor { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع پرداخت")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int PaymentTypeId { get; set; }
        //============================================= 
    }
}
