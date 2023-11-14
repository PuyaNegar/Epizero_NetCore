using DataModels.Base;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ContentsModels
{
    public class TeacherCommentsModel : ModifyDateTimeWithUserModel
    {
        public string Comment { get; set; }
        public DateTime ConfirmedDateTime { get; set; }
       // public bool IsActive { get; set; }
        public bool? IsConfirmed { get; set; }
        public int StudentUserId { get; set; }
        public int TeacherUserId { get; set; }


        public virtual UsersModel StudentUser { get; set; }
        public virtual UsersModel TeacherUser { get; set; }
    }
}
