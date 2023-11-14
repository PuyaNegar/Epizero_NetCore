using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.OnlineExamsViewModels
{
    public class OnlineExamStudentAnswerFilesViewModel
    {
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public int Id  { get; set; } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "شناسه امتحان نبایستی خالی باشد")]
        public int OnlineExamId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public string FilePath { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=  
        /// <summary>
        /// 
        /// </summary>
        public string FileFormat { get; set;  }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 

    }
}
