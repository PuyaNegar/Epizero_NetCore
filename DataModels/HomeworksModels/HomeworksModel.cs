using DataModels.Base;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;

namespace DataModels.HomeworksModels
{
    public class HomeworksModel : ModifyDateTimeWithUserModel
    {
        public HomeworksModel()
        {
            HomeworkAnswers = new HashSet<HomeworkAnswersModel>();
        }
        //=========================================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //=========================================================================
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        //=========================================================================
        /// <summary>
        /// 
        /// </summary>
        public string FilePath { get; set; }
        //=========================================================================
        /// <summary>
        /// 
        /// </summary> 
        public bool IsActive { get; set;  }
        //=========================================================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime ExpiredDate { get; set; }
        //============================================================================================ ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int CourseMeetingId { get; set; }
        //=========================================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingsModel CourseMeeting  { get; set; }
 
        //=========================================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection< HomeworkAnswersModel>   HomeworkAnswers { get; set; }

    }
}
