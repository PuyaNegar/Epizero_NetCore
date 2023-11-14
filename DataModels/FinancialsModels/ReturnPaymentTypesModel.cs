using DataModels.Base;
using System.Collections.Generic;

namespace DataModels.FinancialsModels
{
    public class ReturnPaymentTypesModel : IdentifierModel
    {
        public ReturnPaymentTypesModel()
        {
            StudentReturnPayments = new HashSet<StudentFinancialReturnPaymentsModel>(); 
        } 
        //===================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        public string NameEN { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<StudentFinancialReturnPaymentsModel> StudentReturnPayments { get; set; }
    }
}
