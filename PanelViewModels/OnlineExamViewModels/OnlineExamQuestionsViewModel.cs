using Common.Enums; 
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.OnlineExamViewModels
{
    public class OnlineExamQuestionsViewModel
    {
        public bool IsTextQuestionContext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name ="مفاد آزمون")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int LessonTopicId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "متن سوال")]
        public string QuestionContext { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "سطح سختی سوال")]
        public string DifficultyLevelTypeName { get; set; }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "سوال")]
        public int QuestionId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public int OnlineExamId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public int Inx { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public QuestionType QuestionType { get; set;  }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public MultipleOptionsViewModel MultipleOptions { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    }
     
}
