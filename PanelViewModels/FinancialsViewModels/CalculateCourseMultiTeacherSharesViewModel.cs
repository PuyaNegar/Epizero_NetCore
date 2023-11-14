using System.Collections.Generic;

namespace PanelViewModels.FinancialsViewModels
{
    public class CalculateCourseMultiTeacherSharesViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public long CourseTotalShare { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public long TotalMeetingsShare { get; set;  }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public long TotalPercentageShare { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public long CourseRemainingShare { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public List<MeetingMultiTeacherSharesViewModel> MeetingMultiTeacherShres { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public List<PercentageMultiTeacherSharesViewModel> PercentageMultiTeacherShares { get; set; }
        //===============================================
    }
}
