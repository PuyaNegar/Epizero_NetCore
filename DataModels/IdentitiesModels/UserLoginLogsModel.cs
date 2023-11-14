using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.IdentitiesModels
{
    public class UserLoginLogsModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Int64 Id { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public string LastIp { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public string LastUserAgent { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public string Guid { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastLoginDateTime { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public int LoginCount { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel StudentUser { get; set; }
    }
}
