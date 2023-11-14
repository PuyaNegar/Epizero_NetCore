using DataModels.Base;
using DataModels.IdentitiesModels; 

namespace DataModels.ContentsModels
{
    public class TeacherResumesModel : ModifyDateTimeWithUserModel
    {
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set;  }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive  { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary> 
        public int Inx { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int TeacherUserId { get; set;  }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel TeacherUser { get; set;  }
        //====================================================
    }
}
