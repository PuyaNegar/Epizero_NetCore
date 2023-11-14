using DataModels.Base;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.FinancialsModels
{
   public class StudentPaymentLinksModel : ModifyDateTimeWithUserModel
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsPaid { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseMeetingStudentId { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public int AmountPayable { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PaymentDateTime { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public int? InvoiceId { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public virtual InvoicesModel Invoice { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingStudentsModel CourseMeetingStudent { get; set; }
    }
}
