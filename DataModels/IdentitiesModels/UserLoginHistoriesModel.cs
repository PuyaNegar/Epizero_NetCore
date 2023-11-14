using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.IdentitiesModels
{
   public class UserLoginHistoriesModel : ModifyDateTimeWithUserModel
    {
        public int CountLogin { get; set; }
        public int StudentUserId { get; set; }
        public virtual UsersModel UserStudent { get; set; }
    }
}
