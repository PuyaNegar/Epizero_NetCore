using Common.Enums; 

namespace WebViewModels.TrainingsViewModels
{
   public class StudentCoursesViewModel
    {
        //==========================================================
        /// <summary>
        /// 
        /// </summary>
        public int Id  { get; set; }
        //==========================================================
        /// <summary>
        /// 
        /// </summary>
        public string Name  { get; set; }
        //==========================================================
        /// <summary>
        /// 
        /// </summary>
        public string TeacherFullName { get; set; }
        //==========================================================
        /// <summary>
        /// 
        /// </summary>
        public string StartDateTime { get; set; }
        //==========================================================
        /// <summary>
        /// 
        /// </summary>
        public string EndDateTime { get; set; }
        //==========================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsVisibleOnSite { get; set; }
        //==========================================================
        /// <summary>
        /// 
        /// </summary>
        public CourseCategoryType CourseCategoryType { get; set; }
    }
}
