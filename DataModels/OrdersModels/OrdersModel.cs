using DataModels.Base;
using DataModels.BasicDefinitionsModels;
using DataModels.FinancialsModels;
using DataModels.IdentitiesModels; 
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;

namespace DataModels.OrdersModels
{
    public class OrdersModel : IdentifierModel
    {
        public OrdersModel()
        {
            this.OrderDetails = new HashSet<OrderDetailsModel>();
            this.Invoices = new HashSet<InvoicesModel>();
            this.FinancialTransactions = new HashSet<FinancialTransactionsModel>();
            this.CourseMeetingStudents = new HashSet<CourseMeetingStudentsModel>();
        }
        //*******************************************************************
        /// <summary>
        /// جمع مبلغ (قیمت اصلی محصولات) سفارش
        /// </summary>
        public int SubTotal { get; set; }
        //*******************************************************************
        /// <summary>
        /// جمع مبلغ نهایی(قیمت اصلی محصولات) سفارش
        /// </summary>
        //public int FinalSubTotal { get; set; }
        //******************************************************************* 
        /// <summary>
        /// 
        /// </summary>
        public DateTime OrderStatueDateTime { get; set; }
        //******************************************************************* 
        /// <summary>
        /// جمع مبلغ قابل پرداخت
        /// </summary>
        public int PaymentAmount { get; set; }
        //******************************************************************* 
        /// <summary>
        /// زمان ثبت
        /// </summary>
        public DateTime RegDateTime { get; set; } 
        //*******************************************************************
        /// <summary>
        /// زمان آخرین تغییر
        /// </summary>
        public DateTime? ModDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Score { get; set; }
        //******************************************************************************** Foregin Keys 
        /// <summary>
        /// شناسه مشتری
        /// </summary>
        public int? StudentUserId { get; set; }
        //*******************************************************************
        /// <summary>
        /// مشتری
        /// </summary>
        public virtual UsersModel StudentUser { get; set; }
        //*******************************************************************
        /// <summary>
        /// شناسه صورتحساب
        /// </summary>
        public int? FinalInvoiceId { get; set; }
        //*******************************************************************
        /// <summary>
        /// صورتحساب
        /// </summary>
        public virtual InvoicesModel FinalInvoice { get; set; }
        //*******************************************************************
        /// <summary>
        /// شناسه کاربر تغییردهنده
        /// </summary>
        public int? ModUserId { get; set; }
        //*******************************************************************
        /// <summary>
        /// کاربر تغییردهنده
        /// </summary>
        public virtual UsersModel ModUser { get; set; }
        //*******************************************************************
        /// <summary>
        /// شناسه  وضعیت سفارش
        /// </summary>
        public int OrderStatusTypeId { get; set; }
        //*******************************************************************
        /// <summary>
        /// آخرین وضعیت سفارش
        /// </summary>
        public virtual OrderStatusTypesModel OrderStatusType { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<FinancialTransactionsModel> FinancialTransactions { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<InvoicesModel> Invoices { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OrderDetailsModel> OrderDetails { get; set; }
        //********************************************************************
        /// <summary>
        /// شناسه کد تخفیف
        /// </summary>
        public int? DiscountCodeId  { get; set; }
        //********************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual  DiscountCodesModel    DiscountCode { get; set;  }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseMeetingStudentsModel> CourseMeetingStudents { get; set; }
    }
}
