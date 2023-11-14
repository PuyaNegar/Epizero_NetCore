using DataModels.Base;
using DataModels.IdentitiesModels;
using System.Collections.Generic;

namespace DataModels.BasicDefinitionsModels
{
    public class SchoolTypesModel : IdentifierModel
    {
        public SchoolTypesModel()
        {
            StudentUserProfiles = new HashSet<StudentUserProfilesModel>();
        }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<StudentUserProfilesModel> StudentUserProfiles { get; set; }
        //=============================================
    }
}
