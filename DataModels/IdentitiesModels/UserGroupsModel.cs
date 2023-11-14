using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.IdentitiesModels
{
    public class UserGroupsModel : IdentifierModel
    {
        //====================================================
        public UserGroupsModel()
        {
            Users = new HashSet<UsersModel>();
        }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string TitleEN { get; set; }
        //================================================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<UsersModel> Users { get; set; }
    }
}
