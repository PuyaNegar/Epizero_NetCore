using Newtonsoft.Json;
using System.Collections.Generic;
using TeacherViewModels.UtilityJsonConvertor;

namespace TeacherViewModels.FinancialsViewModels
{
   public class TeacherCourseStudentFinancialsSummeryViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int SumOfDiscountAmount { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int SumOfPrice { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int SumOfSalePartnerPrice { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int SumOfDebtAmount { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int SumOfTotalAmount { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public List<TeacherCourseStudentFinancialsViewModel> CourseStudentFinancials { get; set; }
    }
}
