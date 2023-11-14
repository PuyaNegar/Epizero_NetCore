using DataModels.Base;
using DataModels.IdentitiesModels;

namespace DataModels.ContentsModels
{
   public class AcceptedStudentInEntranceExamsModel : ModifyDateTimeWithUserModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string StudentFullName { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public string PicPath { get; set; }
        //========================================================== ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int? OlympiadMedalTypeId { get; set;  }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual OlympiadMedalTypesModel OlympiadMedalType { get; set;  }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int EntranceExamTypeId { get; set; } 
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual EntranceExamTypesModel EntranceExamType { get; set;  }
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
