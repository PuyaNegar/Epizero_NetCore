using DataModels.Base;
using DataModels.FinancialsModels;
using DataModels.OrdersModels;
using System.Collections.Generic;

namespace DataModels.BasicDefinitionsModels
{
    public class InvoiceTypesModel : IdentifierModel 
    {
        public InvoiceTypesModel()
        {
            this.Invoices = new HashSet<InvoicesModel>();
        } 
        //*******************************************************************
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }

        //==================================================================
        /// <summary>
        /// عنوان لاتین
        /// </summary>
        public string TitleEN { get; set; }

        //*******************************************************************  Navigation
        /// <summary>
        /// صورتحساب‌ها 
        /// </summary>
        public virtual ICollection<InvoicesModel> Invoices { get; set; }
    }
}
