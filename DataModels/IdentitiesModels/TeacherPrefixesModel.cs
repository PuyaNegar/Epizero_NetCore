using DataModels.Base;
using System.Collections.Generic;

namespace DataModels.IdentitiesModels
{
    public class TeacherPrefixesModel : IdentifierModel 
    {
        //====================================================
        public TeacherPrefixesModel()
        {
            TeacherUserProfiles = new HashSet<TeacherUserProfilesModel>();
        }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        //================================================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<TeacherUserProfilesModel> TeacherUserProfiles { get; set; }
    }
}
