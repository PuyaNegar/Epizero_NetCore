using DataModels.Base;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;

namespace DataModels.TrainingManagementModels
{
    public class FAQModel : ModifyDateTimeWithUserModel
    {
        public FAQModel()
        {
                CourseFAQs = new HashSet<CourseFAQsModel>();
        }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public string QuestionContext { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public string AnswerContext { get; set; }
        //============================================= 
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public int Inx { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public bool  IsWebSite { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseFAQsModel> CourseFAQs { get; set; }

    }
}
