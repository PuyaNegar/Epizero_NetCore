using DataModels.Base;
using DataModels.TrainingManagementModels;

namespace DataModels.OnlineExamModels
{
    public class CourseMeetingOnlineExamsModel : ModifyDateTimeWithUserModel
    {
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public int OnlineExamId { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual OnlineExamsModel OnlineExam { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseMeetingId { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingsModel CourseMeeting  { get; set; }
        //=======================================================
    }
}
