

using System.Collections.Generic;

namespace TeacherViewModels.TraningsViewModels
{
   public class TeacherCoursesViewModel
    {
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set;  }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public string StartDate  { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public string EndDate { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseDuration { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public List<TeacherCourseMeetingsViewModel> CourseMeetings  { get; set; }
        //===========================================

    }
}
