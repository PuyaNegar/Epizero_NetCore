using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.TrainingsViewModels
{
   public class StudentCourseGroupsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id  { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set;  }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public List< StudentCourseMeetingsViewModel> StudentCourseMeetings { get; set;  }
        //=================================================
    }
}
