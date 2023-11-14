using System;
using System.Collections.Generic;
using System.Text;

namespace TeacherViewModels.TraningsViewModels
{
    public class TeacherCourseMeetingStudentsViewModel
    {
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set;  }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentFullName { get; set;  }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseMeetingStudentType { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseName    { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public string GenderName { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public string CityName { get; set; }
    }
}
