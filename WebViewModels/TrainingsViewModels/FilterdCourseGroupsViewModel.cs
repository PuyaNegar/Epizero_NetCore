using System.Collections.Generic;

namespace WebViewModels.TrainingsViewModels
{
   public class FilterdCourseGroupsViewModel
    {
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public int LevelId { get; set;  }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string LevelName { get; set;  }


        public string Description { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public List<FilterdCoursesViewModel> FilterdCourses { get; set;  }
        //============================================
    }
}
