using System;
using System.Collections.Generic;
using System.Text;
using WebViewModels.IdentitiesViewModels;

namespace WebViewModels.OnlineExamsViewModels
{
    public class StudentOnlineExamQuestionsWithUserLoginInfoViewModel
    {
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public int OnlineExamId { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
       public List<StudentOnlineExamQuestionsViewModel> StudentOnlineExamQuestions { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public LoginedUsersViewModel LoginedUsers { get; set;  }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public StudentOnlineExamViewModel StudentOnlineExam { get; set;  }

    }
} 
