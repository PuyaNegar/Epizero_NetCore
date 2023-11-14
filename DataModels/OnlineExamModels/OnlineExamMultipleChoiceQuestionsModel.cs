using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.OnlineExamModels
{
    public class OnlineExamMultipleChoiceQuestionsModel : ModifyDateTimeWithUserModel
    {
        public bool IsTextOption1 { get; set; }
        public bool IsTextOption2 { get; set; }
        public bool IsTextOption3 { get; set; }
        public bool IsTextOption4 { get; set; }

        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Option5 { get; set; }

        public string Option1_CkFormat { get; set; }
        public string Option2_CkFormat { get; set; }
        public string Option3_CkFormat { get; set; }
        public string Option4_CkFormat { get; set; }
        public string Option5_CkFormat { get; set; }

        public string DescriptiveAnswer { get; set; }
        public string DescriptiveAnswer_CkFormat { get; set; }


        public int CorrectOption { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=ارتباطات
        public int OnlineExamQuestionsId { get; set; }
        public virtual OnlineExamQuestionsModel OnlineExamQuestion { get; set; }
    }
}
