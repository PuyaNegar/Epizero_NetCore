using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.SystemsModels
{
   public class CourseCategoryTypesModel
    {

        public CourseCategoryTypesModel()
        {
            Courses = new HashSet<CoursesModel>();

        }

        //======================================
        /// <summary>
        /// نام
        /// </summary>
        public int Id { get; set; }
        //======================================
        /// <summary>
        /// نام
        /// </summary>
        public string Name { get; set; }
        //======================================
        /// <summary>
        /// نام انگلیسی
        /// </summary>
        public string NameEN { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<CoursesModel> Courses { get; set; }
    }
}
