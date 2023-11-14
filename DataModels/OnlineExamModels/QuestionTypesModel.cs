using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.OnlineExamModels
{
   public class QuestionTypesModel
    {
        public QuestionTypesModel()
        {
            Questions = new HashSet<QuestionsModel>();
            OnlineExamQuestions = new HashSet<OnlineExamQuestionsModel>();
            OnlineExams = new HashSet<OnlineExamsModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEN { get; set; }
        //=============================================ارتباطات
        public ICollection<QuestionsModel> Questions { get; set; }
        public ICollection<OnlineExamQuestionsModel> OnlineExamQuestions { get; set; }
        public ICollection<OnlineExamsModel> OnlineExams { get; set; }
    }
}
