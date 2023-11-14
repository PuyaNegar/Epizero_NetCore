using System.Collections.Generic;
using DataModels.Base;
using DataModels.IdentitiesModels;

namespace DataModels.TrainingManagementModels
{
    public class LevelsModel : IdentifierModel
    {
        public LevelsModel()
        { 
            Lessons = new HashSet<LessonsModel>();
            StudentUserProfiles = new HashSet<StudentUserProfilesModel>();
        }
        //====================================================
        ///<summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        //================================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int LevelGroupId { get; set; }
        //==================================================== 
        /// <summary>
        /// 
        /// </summary>
        public virtual LevelGroupsModel LevelGroup { get; set; }
        //==================================================== 
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<LessonsModel> Lessons { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StudentUserProfilesModel> StudentUserProfiles { get; set; }

    }
}
