﻿using DataModels.Base;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.TrainingManagementModels
{
   public class MeetingAbsentationsModel : ModifyDateTimeWithUserModel
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsPresent { get; set; }
        //==============================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel StudentUsers { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseMeetingId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingsModel CourseMeeting { get; set; }
        //=====================================================
    }
}
