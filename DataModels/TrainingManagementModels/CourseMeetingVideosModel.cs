using DataModels.Base;

namespace DataModels.TrainingManagementModels
{
   public class CourseMeetingVideosModel : ModifyDateTimeWithUserModel 
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string BannerPicPath { get; set; }
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
        public int CourseMeetingId { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        //public string VideoUniqueId { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingsModel CourseMeeting { get; set; }
        //=========================================================================
    }
}
