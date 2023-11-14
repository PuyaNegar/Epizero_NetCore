using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;

namespace PanelViewModels.TeacherFinancialsViewModels
{
    public class TeacherSattlements2ViewModel
    {
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public int Id  { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyBigIntegerConvertor))]
        public long SattledAmount { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string Date { get; set;  }
        //=================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string CourseName  { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string TeacherPaymentMethod { get; set; }
        //===================================================
    }
}
