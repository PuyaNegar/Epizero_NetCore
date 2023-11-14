using System.Collections.Generic;
using DataModels.Base;

namespace DataModels.TrainingManagementModels
{
    public class CourseTypesModel : IdentifierModel
    {
        public CourseTypesModel()
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
