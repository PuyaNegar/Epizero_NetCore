using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.TrainingsViewModels
{
    public class CommentOldStudentCoursesViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        public string StudentUserFullName { get; set; }
        public string Title { get; set; }
        public string CommentText { get; set; }
        public string CommentAudio { get; set; }
        public string CommentVideo { get; set; }
        public int CommentTypeId { get; set; }
        public int Inx { get; set; }

        public string PersonalPicPath { get; set; }
        public string RegDateTime { get; set; }
    }
}
