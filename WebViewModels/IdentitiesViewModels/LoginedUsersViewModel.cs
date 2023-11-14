﻿using Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WebViewModels.IdentitiesViewModels
{
    public class LoginedUsersViewModel
    {
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public int Id { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public bool IsActive { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public int UserGroupId { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public bool Gender { get; set; }
        //=======================================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public string NationalCode { get; set; }
        //=======================================================================
        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; }
    }
}
