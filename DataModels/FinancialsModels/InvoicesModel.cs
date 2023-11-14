using DataModels.Base;
using DataModels.BasicDefinitionsModels;
using DataModels.IdentitiesModels;
using DataModels.OrdersModels;
using DataModels.SystemsModels;
using System;
using System.Collections.Generic;

namespace DataModels.FinancialsModels
{
    public class InvoicesModel : IdentifierModel
    {
        public InvoicesModel()
        {
            this.Payments = new HashSet<PaymentsModel>();
            this.FinancialTransactions = new HashSet<FinancialTransactionsModel>();
            this.Orders = new HashSet<OrdersModel>();
            StudentPaymentLinks = new HashSet<StudentPaymentLinksModel>();
        }

        //*******************************************************************
        /// <summary>
        /// شماره فاکتور
        /// </summary>
        public string InvoiceNo { get; set; }

        //*******************************************************************
        /// <summary>
        /// تاریخ و ساعت صدور
        /// </summary>
        public DateTime IssuedDateTime { get; set; }

        //*******************************************************************
        /// <summary>
        /// مبلغ کل (جمع مبلغ قابل پرداخت) صورتحساب
        /// </summary>
        public int TotalPrice { get; set; }

        //*******************************************************************
        /// <summary>
        /// زمان آخرین وضعیت صورتحساب
        /// </summary>
        public DateTime InvoiceStatusDateTime { get; set; }
        //****************************************************************** ForeginKey 
        /// <summary>
        /// شناسه نوع صورتحساب
        /// </summary>
        public int InvoiceTypeId { get; set; }
        //******************************************************************
        /// <summary>
        ///  نوع صورتحساب
        /// </summary>
        public virtual InvoiceTypesModel InvoiceType { get; set; }
        //****************************************************************** 
        /// <summary>
        /// شناسه مشتری
        /// </summary>
        public int StudentUserId { get; set; }
        //******************************************************************
        /// <summary>
        /// مشتری
        /// </summary>
        public virtual UsersModel StudentUser { get; set; }
        //****************************************************************** 
        /// <summary>
        /// شناسه وضعیت صورتحساب
        /// </summary>
        public int InvoiceStatusTypeId { get; set; }

        //******************************************************************
        /// <summary>
        /// وضعیت صورتحساب
        /// </summary>
        public virtual InvoiceStatusTypesModel InvoiceStatusType { get; set; }

        //******************************************************************
        /// <summary>
        /// شناسه صورتحساب مرجع
        /// </summary>
        public int? RefInvoiceId { get; set; }

        //******************************************************************
        /// <summary>
        /// صورتحساب مرجع
        /// </summary>
        public virtual InvoicesModel RefInvoice { get; set; }
        //******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OrdersModel> Orders { get; set; }
        //******************************************************************
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Comment { get; set; }
        //*******************************************************************  Navigation
        /// <summary>
        /// 
        /// </summary>
        public int? OrderId { get; set; }
        //******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual OrdersModel Order { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public int? ModUserId { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual  UsersModel ModUser { get; set; }

        //*******************************************************************
        /// <summary>
        /// پرداخت 
        /// </summary>
        public virtual ICollection<PaymentsModel> Payments { get; set; }
        //*******************************************************************
        /// <summary>
        /// پرداخت 
        /// </summary>
        public virtual ICollection<StudentPaymentLinksModel> StudentPaymentLinks { get; set; }
        //*******************************************************************
        /// <summary>
        /// تراکنش‌های مالی 
        /// </summary>
        public virtual ICollection<FinancialTransactionsModel> FinancialTransactions { get; set; }




    }
}
