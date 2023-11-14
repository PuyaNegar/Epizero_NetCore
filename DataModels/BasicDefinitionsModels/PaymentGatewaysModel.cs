using System.Collections.Generic;
using DataModels.Base;
using DataModels.OrdersModels;

namespace DataModels.BasicDefinitionsModels
{
    public class PaymentGatewaysModel : IdentifierModel
    {
        public PaymentGatewaysModel()
        {
            this.Payments = new HashSet<PaymentsModel>();
        } 
        //******************************************************************
        /// <summary>
        /// نام
        /// </summary>
        public string Name { get; set; }
        //*******************************************************************
        /// <summary>
        /// وضعیت (فعال یا غیرفعال)؟
        /// </summary>
        public bool IsActive { get; set; }
        //******************************************************************* Navigation 
        /// <summary>
        /// پرداخت‌ها
        /// </summary>
        public virtual ICollection<PaymentsModel> Payments { get; set; }
    }
}
