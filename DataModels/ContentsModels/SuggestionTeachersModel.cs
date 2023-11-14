using DataModels.Base;
using DataModels.IdentitiesModels;

namespace DataModels.ContentsModels
{
    public class SuggestionTeachersModel : ModifyDateTimeWithUserModel
    {
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        public int Inx { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        public int TeacherUserId { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel TeacherUser  { get; set; }
    }
}
