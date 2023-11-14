using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.FinancialsModels
{
   public class StudentFinancialPaymentTypesModel : IdentifierModel
    {
        public StudentFinancialPaymentTypesModel()
        {
            StudentFinancialPayments = new HashSet<StudentFinancialPaymentsModel>();
        } 
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public int NameEN{ get;set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StudentFinancialPaymentsModel> StudentFinancialPayments  { get; set; }
    }
}
