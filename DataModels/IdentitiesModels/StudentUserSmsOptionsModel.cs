using DataModels.Base;
using DataModels.BasicDefinitionsModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.IdentitiesModels
{
   public class StudentUserSmsOptionsModel : ModifyDateTimeWithUserModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int SmsOptionId { get; set; }
        //========================================
        /// <summary>
        /// 
        /// </summary>
        public virtual SmsOptionsModel SmsOption{ get; set; }
        //=========================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //=========================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel StudentUser  { get; set; }
    }
}
