using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.OnlineExamModels
{
   public class MultipleChoiceQuestionAnswersModel : ModifyDateTimeWithUserModel
    {
        public int SelectedOption { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=ارتباطات
        public int OnlineExamStudentAnswerId { get; set; }
        public virtual OnlineExamStudentAnswersModel OnlineExamStudentAnswer { get; set; }
    }
}
