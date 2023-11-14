using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace PanelViewModels.FinancialsViewModels
{
    public class StudentFinesViewModel
    {
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شرح سند")]
        [StringLength(2000, ErrorMessage = "فیلد نبایستی بیش از 2000 کاراکتر باشد")]
        public string Description { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>    
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")] 
        [Display(Name = "مبلغ جریمه (تومان)")] 
        public int Amount { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int StudentUserId { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentFullName { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [RegularExpression(@"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فرمت تاریخ بایستی بصورت 1390/05/06 باشد")]
        public string RegDateTime { get; set; }
        //=============================================
        [Display(Name = "دوره")]
        [Required(ErrorMessage = "جلسه نبایستی خالی باشد")]
        public int CourseMeetingStudentId { get; set; }
        //================================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseName { get; set; }
        //================================================
        public string UserEditor { get; set; }
    }
}
