using Newtonsoft.Json;
using TeacherViewModels.UtilityJsonConvertor;

namespace TeacherViewModels.FinancialsViewModels
{
   public class TeacherCourseStudentFinancialsViewModel
    {
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentFullName { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseMeetingStudentType { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseName { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public string GenderName { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public string CityName { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsTemporaryRegistration { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public  int DiscountAmount { get; set;  }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int Price { get; set;  }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int SalePartnerPrice { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int DebtAmount { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int TotalAmount { get; set;  }
        //==================================================
    }
}
