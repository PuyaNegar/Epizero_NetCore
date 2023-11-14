using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.BasicDefinitionsModels
{
    public class IntroductionWithAcademyTypesModel
    {
        public IntroductionWithAcademyTypesModel()
        {
            StudentUserProfiles = new HashSet<StudentUserProfilesModel>();
        }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public string NameEn { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StudentUserProfilesModel> StudentUserProfiles { get; set; }
    }
}
