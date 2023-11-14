using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.OnlineExamModels
{
    public class OnlineExamDescriptiveQuestionsModel : ModifyDateTimeWithUserModel
    {
        public string QuestionAnswerContext { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=ارتباطات
        public int OnlineExamQuestionsId { get; set; }
        public virtual OnlineExamQuestionsModel OnlineExamQuestion { get; set; }
    }
}
