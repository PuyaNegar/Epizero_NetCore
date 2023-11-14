using PanelViewModels.FinancialsViewModels;
 
using System.Collections.Generic;
 

namespace PanelViewModels.TeacherFinancialsViewModels
{
    public class TeacherMultiCoursesShareViewModel
    {
        //=========================================
        /// <summary>
        /// 
        /// </summary>
        public long TotalMeetingShare { get; set; }
        //=========================================
        /// <summary>
        /// 
        /// </summary>
        public long TotalPercentageShare { get; set; }
        //=========================================
        /// <summary>
        /// 
        /// </summary>
        public long TotalShare { get; set; }
        //=========================================
        /// <summary>
        /// 
        /// </summary>
        public List<MeetingMultiTeacherSharesViewModel> MeetingMultiTeacherShares { get; set; }
        //=========================================
        /// <summary>
        /// 
        /// </summary>
        public List<PercentageMultiTeacherSharesViewModel> PercentageMultiTeacherShares { get; set;  }

    }
}
