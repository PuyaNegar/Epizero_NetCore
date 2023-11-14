using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.IdentitiesModels
{
    public class SendSMSTargetsModel : ModifyDateTimeWithUserModel
    {
        //========================================================================
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }
        //========================================================================
        /// <summary>
        /// شماره موبایل
        /// </summary>
        public string MobNo { get; set; }
        //========================================================================
        /// <summary>
        /// وضعیت فعال بودن
        /// </summary>
        public bool IsActive { get; set; }
        //======================================================================== روابط

    }
}
