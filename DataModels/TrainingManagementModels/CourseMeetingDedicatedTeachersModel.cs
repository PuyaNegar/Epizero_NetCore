using DataModels.Base;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.TrainingManagementModels
{
    public class CourseMeetingDedicatedTeachersModel : ModifyDateTimeWithUserModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int CourseMeetingId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingsModel CourseMeeting { get; set; }
        //=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public int TeacherUserId { get; set; }
        //=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel TeacherUser { get; set; }
    }
}
