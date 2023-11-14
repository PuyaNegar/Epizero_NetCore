
using System;

namespace PanelViewModels.FinancialsViewModels
{
    public class MeetingMultiTeacherSharesViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        public int Amount { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseMeetingsCount { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        public long TotalAmount { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        public int TeacherUserId  { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        public string TeacherFullName  { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseOrExamName { get; set; }
    }
}
