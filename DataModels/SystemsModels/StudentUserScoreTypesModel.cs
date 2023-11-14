using DataModels.Base;
using DataModels.FinancialsModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.IdentitiesModels
{
   public class StudentUserScoreTypesModel :  IdentifierModel
    {
        public StudentUserScoreTypesModel()
        {
           UserScores = new HashSet<StudentUserScoresModel>();
        }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string NameEN { get; set; }
        //==========================================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<StudentUserScoresModel> UserScores { get; set; }
    }
}
