using DataModels.Base; 
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.BasicDefinitionsModels
{
    public class ScoringTariffsModel : ModifyDateTimeWithUserModel
    { 
        //*******************************************************************
        /// <summary>
        /// اولویت
        /// </summary>
        public int Score { get; set; }
        //*******************************************************************
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }
        //*******************************************************************  
    }
}
