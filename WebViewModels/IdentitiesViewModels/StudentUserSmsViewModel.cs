
using System.Collections.Generic;

namespace WebViewModels.IdentitiesViewModels
{
    public class StudentUserSmsViewModel
    {
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public List<StudentUserSmsOptionsViewModel> StudentUserSmsOptions { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public int UserSmsCredit { get; set;  }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserCredit { get; set; }
        //===================================================
    }
}
