using DataModels.Base;

namespace DataModels.TrainingManagementModels
{
   public class CourseMeetingBookletsModel : ModifyDateTimeWithUserModel 
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
        public string FilePath { get; set; }
        //=====================================================
        /// <summary>
        ///  
        /// </summary>
        public bool IsActive { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public int CourseMeetingId { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingsModel CourseMeeting { get; set; }
        //=========================================================================
    }
}
