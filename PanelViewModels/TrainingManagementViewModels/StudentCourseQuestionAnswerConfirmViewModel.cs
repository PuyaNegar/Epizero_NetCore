
using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.TrainingManagementViewModels
{
    public class StudentCourseQuestionAnswerConfirmViewModel
    {
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string AnswerContext { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string QuestionContext { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsVerified { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsBestAnswer { get; set;  }
    }
}
