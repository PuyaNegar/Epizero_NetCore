using System.ComponentModel.DataAnnotations;

namespace WebViewModels.OnlineExamsViewModels
{
   public class StudentMultipeChoiceAnswerViewModel
    {
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "شناسه سوال نبایستی خالی باشد")]
        public int OnlineExamQuestionId { get; set;  } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public int SelectedOption { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "شناسه امتحان نبایستی خالی باشد")]
        public int OnlineExamId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
         
    
    }
}
