using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.TrainingsViewModels
{
    public class StudentAccessToCourseViewModel
    {
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsAccessToEntireCourse { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<int> AvalibleCourseMeetingIds { get; set; }
    }
}
