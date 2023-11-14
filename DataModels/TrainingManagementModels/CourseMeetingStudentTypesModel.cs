using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.TrainingManagementModels
{
   public class CourseMeetingStudentTypesModel
    {
        public CourseMeetingStudentTypesModel()
        {
            CourseMeetingStudents = new HashSet<CourseMeetingStudentsModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEN { get; set; }
        //======================================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseMeetingStudentsModel> CourseMeetingStudents { get; set; }
    }
}
