using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.OnlineExamModels
{
   public class DifficultyLevelTypesModel
    {
        public DifficultyLevelTypesModel()
        {
            this.Questions = new HashSet<QuestionsModel>();
            this.OnlineExamQuestions = new HashSet<OnlineExamQuestionsModel>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameEN { get; set; }
        //====================================================================ارتباطات
        public virtual ICollection<QuestionsModel> Questions { get; set; }
        public virtual ICollection<OnlineExamQuestionsModel> OnlineExamQuestions { get; set; }
    }
}
