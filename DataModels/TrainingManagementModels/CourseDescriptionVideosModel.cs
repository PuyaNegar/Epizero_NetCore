using DataModels.Base;

namespace DataModels.TrainingManagementModels
{
   public class CourseDescriptionVideosModel : ModifyDateTimeWithUserModel 
    {
        /// <summary>
        /// اولویت
        /// </summary>
        public int Inx { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        //=====================================================
        /// <summary>
        ///  
        /// </summary>
        public bool IsActive { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Link { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseId { get; set; }
 
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CoursesModel Course { get; set; }
        //=========================================================================
    }
}
