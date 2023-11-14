using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.OnlineExamModels
{
   public class DescriptiveQuestionsModel : ModifyDateTimeWithUserModel
    {
        public string QuestionAnswerContext { get; set; }
        public string QuestionAnswerContext_Html { get; set; }
        //====================================================ارتباطات
        public int QuestionId { get; set; }
        public virtual QuestionsModel Question { get; set; }
    }
}
