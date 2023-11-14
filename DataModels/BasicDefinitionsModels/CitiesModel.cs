using DataModels.Base;
using DataModels.FinancialsModels;
using DataModels.IdentitiesModels;
using System.Collections.Generic;

namespace DataModels.BasicDefinitionsModels
{
    public class CitiesModel : ModifyDateTimeWithUserModel
    {
        public CitiesModel()
        {
            TeacherPercentages = new HashSet<TeacherPercentagesModel>();
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } 
        //===========================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int ProvinceId { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ProvincesModel Province { get; set; }
        //===========================================================  
        /// <summary>
        /// 
        /// </summary>
        public ICollection<StudentUserProfilesModel> StudentUserProfiles { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<TeacherUserProfilesModel> TeacherUserProfiles { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<TeacherPercentagesModel> TeacherPercentages  { get; set; }

    }
}
