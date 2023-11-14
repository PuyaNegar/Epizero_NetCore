using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.OnlineExamModels
{
    public class OnlineExamAnalysisModel : ModifyDateTimeWithUserModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string FilePath { get; set; }
        //=====================================================
        /// <summary>
        ///  
        /// </summary>
        public bool IsActive { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public int OnlineExamsId { get; set; }
        //======================================================
        public virtual OnlineExamsModel OnlineExams { get; set; }
    }
}
