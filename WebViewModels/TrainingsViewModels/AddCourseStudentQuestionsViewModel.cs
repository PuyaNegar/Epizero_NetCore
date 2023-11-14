
using System.ComponentModel.DataAnnotations;

namespace  WebViewModels.TrainingsViewModels
{
   public class AddCourseStudentQuestionsViewModel
    {
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "متن سوال")]
        [Required(ErrorMessage = "   متن سوال نبایستی خالی باشد")]
        public string  Context { get; set; }
        //============================================== 
        /// <summary>
        /// 
        /// </summary>
 
        [Required(ErrorMessage = "شناسه دوره نبایستی خالی باشد")]
        public int CourseId { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "عکس")]
        public string QuestionPicPath { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "فایل")]
        public string QuestionFilePath { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "صوت")]
        public string AudioPath { get; set; }
    }
}
