using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.FinancialsViewModels
{
   public class StudentPaymentLinksViewModel
    {
        public int Id { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseMeetingName { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseName { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentFullName { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string IsPaidName { get; set; }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public int AmountPayable { get; set; }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public int TotalAmountPayable  { get; set; }
    }
}
