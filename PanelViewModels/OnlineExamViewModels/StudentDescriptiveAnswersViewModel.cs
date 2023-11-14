using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.OnlineExamsViewModels
{
    public class StudentDescriptiveAnswersViewModel
    {
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "شناسه سوال نبایستی خالی باشد")]
        public int OnlineExamQuestionId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public string AnswerContext { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "شناسه امتحان نبایستی خالی باشد")]
        public int OnlineExamId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
    }
}
