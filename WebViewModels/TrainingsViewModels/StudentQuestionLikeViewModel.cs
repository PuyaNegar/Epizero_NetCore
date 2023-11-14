using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebViewModels.TrainingsViewModels
{
    public class StudentQuestionLikeViewModel
    {
        [Display(Name = "سوال دانش آموز در دوره")]
        [Required(ErrorMessage = "شناسه {0} نبایستی خالی باشد")]
        public int CourseStudentQuestionId { get; set; }
 
    }
}
