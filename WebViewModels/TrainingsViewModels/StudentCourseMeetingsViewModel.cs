using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.TrainingsViewModels
{
   public class StudentCourseMeetingsViewModel
    {
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseMeetingId { get; set;  }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set;  }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string TeacherFullName { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public bool HasBooklet { get; set;  }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public bool HasHomework { get; set;  }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public float? HomeworkAverageGrade { get; set;  }

    }
}
