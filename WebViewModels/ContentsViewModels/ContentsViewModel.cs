using System.Collections.Generic;
 

namespace WebViewModels.ContentsViewModels
{
    public  class ContentsViewModel
    {
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public List<RssViewModel> Rss { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public List<SlidersViewModel> Sliders { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public List<OnlineExamPromoSectionsViewModel> OnlineExamPromoSections { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public List<CoursePromoSectionsViewModel> CoursePromoSections { get; set;  }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public List<SuggestionTeachersViewModel> SuggestionTeachers { get; set;  }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public HomePageNotificationsViewModel HomePageNotification  { get; set; }
        //======================================================
        /// <summary>
        /// تعداد دانش آموزان
        /// </summary>
        public int NumberOfStudent { get; set; }
        //======================================================
        /// <summary>
        /// تعداد آزمونهای برگزار شده
        /// </summary>
        public int NumberOfOnlineExams { get; set; }
        //======================================================
        /// <summary>
        /// تعداد ساعات آموزشی
        /// </summary>
        public int NumberOfOnlineClasses { get; set; }

    }
}
