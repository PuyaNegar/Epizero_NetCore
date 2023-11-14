using DataModels.Base;
using System; 

namespace DataModels.TrainingManagementModels
{
    public class OnlineClassesModel : IdentifierModel
    {
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartTime { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public string RecordUrl { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public string MeetingId { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsIgnoreClass { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsAbleToAccessRecordUrl { get; set; }
        //============================================================= ارتباطات  
        /// <summary>
        /// 
        /// </summary>
        public int CourseMeetingId { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingsModel CourseMeeting { get; set; }
        //=============================================================



    }
}
