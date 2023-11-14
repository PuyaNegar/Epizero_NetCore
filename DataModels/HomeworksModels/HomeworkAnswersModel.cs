using DataModels.Base;
using DataModels.IdentitiesModels; 
using System.Collections.Generic;

namespace DataModels.HomeworksModels
{
    public class HomeworkAnswersModel : ModifyDateTimeWithUserModel
    {
       
        //=============================================================================== ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int HomeWorkId { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set;  }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public string FilePath { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public float? Grade { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual HomeworksModel HomeWork { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel StudentUser {get;set; } 
        //=============================================================
    }
}
