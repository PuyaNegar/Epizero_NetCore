using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.FinancialsViewModels
{
   public class ReadStudentPaymentLinksViewModel
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
        public string PaymentDateTime { get; set; }
        //========================================== 
        /// <summary>
        /// 
        /// </summary>
        public bool IsPaid { get; set; }
        //========================================== 
        /// <summary>
        /// 
        /// </summary>
        public string InvoiceNo { get; set; }
    }
}
