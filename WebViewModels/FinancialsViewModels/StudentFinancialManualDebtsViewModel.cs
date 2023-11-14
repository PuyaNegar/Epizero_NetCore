using Newtonsoft.Json;
 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebViewModels.UtilityJsonConvertor;

namespace WebViewModels.FinancialsViewModels
{
   public class StudentFinancialManualDebtsViewModel
    {
 
        /// <summary>
        ///    
        /// </summary>
        public int Id { get; set; }
        //===================================================== 
        /// <summary>
        /// نام بانک
        /// </summary>
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
         [Display(Name = "مبلغ بدهی")]
        [Required(ErrorMessage = "مبلغ بدهی را وارد کنید")]
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int DebtAmount { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دوره")]
        [Required(ErrorMessage = "دوره نبایستی خالی باشد")]
        public int CourseMeetingStudentId { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string CourseName { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string CourseMeetingStudentType { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string UserEditor { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>

        public string RegDateTime { get; set; }
    }
}
