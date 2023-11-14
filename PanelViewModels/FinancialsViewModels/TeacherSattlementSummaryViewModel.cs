using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.FinancialsViewModels
{
    public class TeacherSattlementSummaryViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مبلغ باقیمانده (تومان)")]
        [JsonConverter(typeof(CurrencyBigIntegerConvertor))]
        public long RemaningDebtAmount { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام دوره")]
        public string CourseName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام معلم")]
        public string TeacherUserFullName  { get; set; } 
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name= "مجموع بدهی این دوره (تومان) ")]
        [JsonConverter(typeof(CurrencyBigIntegerConvertor))]
        public long TotalDebtAmount { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "مجموع تسویه ها (تومان)")]
        [JsonConverter(typeof(CurrencyBigIntegerConvertor))]
        public long TotalSattledAmount { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نحوه پرداخت")]
        public string TeacherPaymentMethodType { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "هزینه")]
        public int Fee { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "درصد")]
        public int Percent { get; set; }
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
        public int TeacherPaymentMethodTypeId { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public List<TeacherSattlementSchedulesViewModel> TeacherSattlementSchedules { get; set; }
    }
}
