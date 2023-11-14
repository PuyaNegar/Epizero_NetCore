using DataModels.Base;
using DataModels.BasicDefinitionsModels; 

namespace DataModels.FinancialsModels
{
    public class TeacherPercentagesModel : ModifyDateTimeWithUserModel
    {
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public int Percent { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public float Number1 { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public float Number2 { get; set; } 
        //================================================= ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int? CityId { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CitiesModel City { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public int TeacherPaymentMethodId { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual TeacherPaymentMethodsModel TeacherPaymentMethod { get; set; }
        //=================================================
    }
}
