using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.ContentsViewModels
{
   public class CourseDedicatedTeachersViewModel
    {
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseId  { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int TeacherUserId  { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string TeacherFullName { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string PersonalPicPath { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsIndexTeacher { get; set; }
    }
}
