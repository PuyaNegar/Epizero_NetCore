using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.OnlineExamModels
{
   public class MultipleChoiceQuestionsModel : ModifyDateTimeWithUserModel
    {

        public bool IsTextOption1 { get; set; }
        public bool IsTextOption2 { get; set; }
        public bool IsTextOption3 { get; set; }
        public bool IsTextOption4 { get; set; }

        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        //public string Option5 { get; set; }
        public string Option1_Html{ get; set; }
        public string Option2_Html { get; set; }
        public string Option3_Html { get; set; }
        public string Option4_Html { get; set; }
        //public string Option5_Html { get; set; }
        public string DescriptiveAnswer_Html { get; set; }
        /// <summary>
        /// پاسخ تشریحی
        /// </summary>
        public string DescriptiveAnswer { get; set; }
        public int CorrectOption { get; set; }
     
        //==========================================================ارتباطات
        public int QuestionId { get; set; }
        public virtual QuestionsModel Question { get; set; }

    }
}
