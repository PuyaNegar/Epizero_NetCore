using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.FinancialsViewModels
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
        //===================================================
        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = " تاریخ ثبت نبایستی خالی باشد")]
        [RegularExpression(@"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فرمت تاریخ بایستی بصورت 1390/05/06 باشد")]
        public string RegDateTime { get; set; }
    }
}
