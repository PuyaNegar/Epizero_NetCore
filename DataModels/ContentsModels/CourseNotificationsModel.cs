using DataModels.Base;
using DataModels.TrainingManagementModels;
using System; 

namespace DataModels.ContentsModels
{
   public class CourseNotificationsModel  : IdentifierModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int CourseId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public virtual CoursesModel Course { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public int NotificationId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public virtual NotificationsModel Notification { get; set; }
    }
}
