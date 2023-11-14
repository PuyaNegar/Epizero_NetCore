using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.TrainingsViewModels
{
    public class ReadCourseStudentNewCommentsViewModel
    {
        public int Id { get; set; }
        public string StudentUserFullName { get; set; }
        public string Comment  { get; set; }
        public string PersonalPicPath { get; set; }
        public string RegDateTime { get; set; }
    }
}
