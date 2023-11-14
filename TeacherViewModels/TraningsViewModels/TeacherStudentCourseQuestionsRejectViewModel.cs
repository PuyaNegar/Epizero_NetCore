using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeacherViewModels.TraningsViewModels
{
   public class TeacherStudentCourseQuestionsRejectViewModel
    {
        [Required(ErrorMessage = "شناسه سوال نبایستی خالی باشد")]
        public int QuestionId  { get; set; }
    }
}
