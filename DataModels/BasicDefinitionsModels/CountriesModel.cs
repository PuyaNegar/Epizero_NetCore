using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.BasicDefinitionsModels
{
    public class CountriesModel : IdentifierModel
    { 
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //=======================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public ICollection<ProvincesModel> Provinces  { get; set; }
    }
}
