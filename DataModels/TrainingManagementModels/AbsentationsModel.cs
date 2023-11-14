using DataModels.Base;
using DataModels.IdentitiesModels;
using System;
 

namespace DataModels.TrainingManagementModels
{
    public class AbsentationsModel : ModifyDateTimeWithUserModel
    
    {  
        //==============================================================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date { get; set; }
        //==============================================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsPresent { get; set; }  
        //==============================================================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //==============================================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel StudentUser { get; set; }
        //============================================================================== 
        /// <summary>
        /// 
        /// </summary>
        public int CourseMeetingId { get; set; }
        //==============================================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingsModel CourseMeeting { get; set; }
        //==============================================================================
    }
}
