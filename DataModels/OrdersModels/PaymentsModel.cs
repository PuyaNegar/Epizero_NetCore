using DataModels.Base;
using DataModels.BasicDefinitionsModels;
using DataModels.FinancialsModels;
using DataModels.SystemsModels;
using System;

namespace DataModels.OrdersModels
{
    public class PaymentsModel : IdentifierModel 
    { 
        //******************************************************************
        /// <summary>
        /// مبلغ پرداخت
        /// </summary>
        public int Amount { get; set; } 
        //*******************************************************************
        /// <summary>
        /// شماره تراکنش - پیگیری
        /// </summary>
        public string TrackingNo { get; set; }

        //******************************************************************
        /// <summary>
        /// تاریخ و ساعت پرداخت
        /// </summary>
        public DateTime PaymentDateTime { get; set; }

        //****************************************************************** ForeginKey 
        /// <summary>
        /// شناسه صورتحساب
        /// </summary>
        public int InvoiceId { get; set; }

        //*******************************************************************
        /// <summary>
        /// صورتحساب
        /// </summary>
        public virtual InvoicesModel Invoice { get; set; }

        //****************************************************************** 
        /// <summary>
        /// شناسه درگاه
        /// </summary>
        public int PaymentGatewayId { get; set; }

        //*******************************************************************
        /// <summary>
        /// درگاه
        /// </summary>
        public virtual PaymentGatewaysModel PaymentGateway { get; set; }

    }
}
