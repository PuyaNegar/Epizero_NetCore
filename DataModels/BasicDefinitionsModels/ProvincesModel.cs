using DataModels.Base;
using System.Collections.Generic;

namespace DataModels.BasicDefinitionsModels
{
    public class ProvincesModel :  ModifyDateTimeWithUserModel
    {
        public ProvincesModel()
        {
            this.Cities = new HashSet<CitiesModel>();
        }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //=======================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int CountryId  { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CountriesModel Country { get; set;  }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<CitiesModel> Cities { get; set; }
        //=======================================================
    }
}
