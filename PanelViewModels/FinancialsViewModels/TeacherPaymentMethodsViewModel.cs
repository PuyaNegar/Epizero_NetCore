using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.FinancialsViewModels
{
   public class TeacherPaymentMethodsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "استاد")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int TeacherId { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string TeacherFullName { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دوره")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int CourseId { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دوره")]
        public string CourseName { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>

        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int? PercentOrFee { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "عدد اول")]
        public float? Number1 { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "عدد دوم")]
        public float? Number2 { get; set; } 
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نحوه ی پرداخت")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int TeacherPaymentMethodTypeId { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string TeacherPaymentMethodTypeName { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public long TotalSattledAmount  { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public long TotalDebtAmount { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات")]
        [StringLength(600,ErrorMessage ="توضیحات نباید بالای 600 کارکتر باشد")]
        public string Comment { get; set; }
        //=======================================================


    }
}
