using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.ContentsViewModels
{
    public class AcceptedStudentInEntranceExamGroupsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int EntranceExamTypeId { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string EntranceExamTypeName { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public List<AcceptedStudentInEntranceExamsViewModel> AcceptedStudentInEntranceExams { get; set; }
    }
}
