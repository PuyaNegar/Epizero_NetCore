using DataModels.Base;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ContentsModels
{
    public class HomePageNotificationsModel : ModifyDateTimeWithUserModel
    {
        public bool IsActive { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public string Link { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public string PicPath { get; set; }

    }
}
