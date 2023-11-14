using System;
using System.Collections.Generic;
using System.Text;
using DataModels.Base;

namespace DataModels.TrainingManagementModels
{
    public class LevelGroupsModel : IdentifierModel
    {
        public LevelGroupsModel()
        {
            Levels=new HashSet<LevelsModel>();
        }
        //====================================================
        ///<summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //====================================================
        ///<summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //==================================================== 
        /// <summary>
        /// 
        /// </summary>
        public ICollection<LevelsModel> Levels { get; set; }
    }
}
