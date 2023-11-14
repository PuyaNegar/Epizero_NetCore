using DataModels.Base;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ContentsModels
{
    public class NotificationsModel : ModifyDateTimeWithUserModel
    {
        public NotificationsModel()
        {
            CourseNotifications = new HashSet<CourseNotificationsModel>();
        }
        public bool IsActive { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public DateTime FromDate { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public DateTime ToDate { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseNotificationsModel> CourseNotifications { get; set; }
    }
}
