using DataModels.Base;
using DataModels.TrainingManagementModels;
using System.Collections.Generic;

namespace DataModels.BasicDefinitionsModels
{
   public class LanguagesModel : IdentifierModel 
    {
        public LanguagesModel()
        {
            Courses = new HashSet<CoursesModel>();
        }
        //====================================================
        ///<summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //====================================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CoursesModel> Courses { get; set; }
    }
}
