

using System.ComponentModel.DataAnnotations;

namespace WebViewModels.TrainingsViewModels
{
   public class AddCourseStudentQuestionAnswersViewModel
    {
        //=============================================

        /// <summary>
        /// 
        /// </summary>
        public string AnswerPicPath { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        public string AnswerFilePath { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "متن پاسخ")]
        [Required(ErrorMessage = "   متن پاسخ نبایستی خالی باشد")]
        public string AnswerContext { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int StudentQuestionId { get; set;  }
        //==============================================  
        /// <summary>
        /// 
        /// </summary>
        public string AudioPath { get; set; }
    }
}
