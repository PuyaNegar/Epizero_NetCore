
using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;

namespace PanelViewModels.TeacherFinancialsViewModels
{
   public class TeacherSettlementAggregationSummeryViewModel
    {
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyBigIntegerConvertor))]
        public long TotalSettledAmount { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public long TotalSettledCount  { get; set; }
        //=======================================================
    }
}
