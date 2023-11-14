using DataModels.Base;
using System.Collections.Generic;

namespace DataModels.OnlineExamModels
{
    public class OnlineExamTypesModel : IdentifierModel
    {
        public OnlineExamTypesModel()
        {
            OnlineExams = new HashSet<OnlineExamsModel>();
        }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<OnlineExamsModel> OnlineExams { get; set; }
        //=============================================
    }
}
