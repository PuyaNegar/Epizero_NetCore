using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.OnlineExamModels
{
   public class OnlineExamStudentAnswersModel : ModifyDateTimeWithUserModel
    {
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=ارتباطات
        public int OnlineExamStudentId { get; set; }
        public virtual OnlineExamStudentsModel OnlineExamStudent { get; set; }
        public int OnlineExamQuestionId { get; set; }
        public virtual OnlineExamQuestionsModel OnlineExamQuestion { get; set; }

        public virtual MultipleChoiceQuestionAnswersModel MultipleChoiceQuestionAnswer { get; set; }
        public virtual DescrptiveQuestionAnswersModel DescrptiveQuestionAnswer { get; set; }
    }
}
