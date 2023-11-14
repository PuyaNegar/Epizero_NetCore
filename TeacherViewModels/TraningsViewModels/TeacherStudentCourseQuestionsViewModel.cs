using System.Collections.Generic;

namespace TeacherViewModels.TraningsViewModels
{
    public class TeacherStudentCourseQuestionsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id  { get; set; }
         //=================================================
        /// <summary>
        /// 
        /// </summary>
        public string QuestionContext  { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseStatusType { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public string VerifiedDateTime { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public string RegDateTime { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public int UnVerifiedAnswerCount { get; set; }
        //================================================= 
        /// <summary>
        /// 
        /// </summary>
        public string StudentUserFullName { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseName { get; set; }
        //============================================

    }
}
