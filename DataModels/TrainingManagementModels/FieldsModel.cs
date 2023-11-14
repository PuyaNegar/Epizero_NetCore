using DataModels.Base;
using DataModels.IdentitiesModels;
using DataModels.OnlineExamModels;
using System.Collections.Generic;

namespace DataModels.TrainingManagementModels
{
    public class FieldsModel : IdentifierModel
    {
        //============================================
        public FieldsModel()
        { 
            Lessons = new HashSet<LessonsModel>();
            StudentUserProfiles = new HashSet<StudentUserProfilesModel>();
            OnlineExamFields = new HashSet<OnlineExamFieldsModel>();
        }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //============================================
        /// <summary>
        /// وضعیت
        /// </summary>
        public bool IsActive  { get; set; }
        //=============================================================== ارتباطات 
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<LessonsModel> Lessons { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StudentUserProfilesModel> StudentUserProfiles { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OnlineExamFieldsModel> OnlineExamFields { get; set; }

    }
}
