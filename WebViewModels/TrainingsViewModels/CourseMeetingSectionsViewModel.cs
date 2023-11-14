using System.Collections.Generic;

namespace WebViewModels.TrainingsViewModels
{
    public class CourseMeetingSectionsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string StudentUserFullName { get; set;  }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentMobNo { get; set;  } 
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public List<CourseMeetingBookletsViewModel> CourseMeetingBooklets { get; set;  }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public List<CourseMeetingVideosViewModel> CourseMeetingVideos { get; set;  }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public List<HomeworksViewModel> Homeworks { get; set;  }
        //=======================================
    }
}
