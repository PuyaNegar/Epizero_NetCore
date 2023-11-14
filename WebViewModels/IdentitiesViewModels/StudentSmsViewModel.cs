using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.IdentitiesViewModels
{
   public class StudentSmsViewModel
    {
        public int StudentSmsCredit { get; set; }
        public int Balance { get; set; }
        public List<StudentUserSmsOptionsViewModel> StudentUserSmsOptions { get; set; }
    }
}
