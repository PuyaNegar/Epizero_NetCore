using DataModels.Base;
using DataModels.FinancialsModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.BasicDefinitionsModels
{
   public class CourseMultiTeacherShareTypesModel : IdentifierModel
    {
        public CourseMultiTeacherShareTypesModel()
        {
            CourseMultiTeacherShares = new HashSet<CourseMultiTeacherSharesModel>();
        }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public string NameEn { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseMultiTeacherSharesModel> CourseMultiTeacherShares { get; set; }
    }
}
