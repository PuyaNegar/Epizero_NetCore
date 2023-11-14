using DataModels.Base; 

namespace DataModels.OnlineExamModels
{
   public class OnlineExamStudentAnswerFilesModel : ModifyDateTimeWithUserModel
    {
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        public string FilePath { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=ارتباطات 
        /// <summary>
        /// 
        /// </summary>
        public int OnlineExamStudentId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        public virtual OnlineExamStudentsModel OnlineExamStudent { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    }
}
