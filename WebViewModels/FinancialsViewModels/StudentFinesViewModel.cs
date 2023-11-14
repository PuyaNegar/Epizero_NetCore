using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.FinancialsViewModels
{
  public  class StudentFinesViewModel
    {
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>    
        public int Amount { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary> 
        public int StudentUserId { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentFullName { get; set; }
        //=============================================
    }
}
