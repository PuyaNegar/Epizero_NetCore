
using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.FinancialsViewModels
{
    public class StudentFinancialPaymentsViewModel
    {
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public string RequestReferenceNumber { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int AmountPaid { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentUserFullName { get; set; }
        //======================================= 
        /// <summary>
        /// 
        /// </summary>
        public string StudentFinancialPaymentTypeName { get; set; }
        //======================================= 
        /// <summary>
        /// 
        /// </summary>
        public int StudentFinancialPaymentTypeId { get; set;  }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public string AmountPaidDateTime { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دوره")]
        [Required(ErrorMessage = "جلسه نبایستی خالی باشد")]
        public int CourseMeetingStudentId { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseName  { get; set; }



        public string UserEditor { get; set; }
    }
}
