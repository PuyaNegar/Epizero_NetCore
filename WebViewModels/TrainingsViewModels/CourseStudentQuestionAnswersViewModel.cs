 

namespace WebViewModels.TrainingsViewModels
{
   public class CourseStudentQuestionAnswersViewModel
    {
        public string AnswerAudioPath { get; set; }
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
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public int Id  { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public string AnsweredUserFullName { get; set; }
        public string AnswerdUserPicPath { get; set; }


        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public string RegDateTime { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public string AnswerContext  { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsBestAnswer { get; set; }
    
    }
}
