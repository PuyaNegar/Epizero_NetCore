using DataModels.Base;
using DataModels.OrdersModels;
using System;

namespace DataModels.FinancialsModels
{
    public class FinancialTransactionsModel : IdentifierModel
    { 
        //===============================================
        /// <summary>
        /// موجودی قبلی
        /// </summary>
        public int PreviousBalance { get; set; }

        //===============================================
        /// <summary>
        /// مبلغ واریز
        /// </summary>
        public int DepositAmount { get; set; }

        //===============================================
        /// <summary>
        /// مبلغ برداشت
        /// </summary>
        public int WithdrawalAmount { get; set; }

        //===============================================
        /// <summary>
        /// مانده
        /// </summary>
        public int Balance { get; set; }

        //===============================================
        /// <summary>
        /// تاریخ و زمان ثبت
        /// </summary>
        public DateTime RegDateTime { get; set; }

        //====================================================== ارتباطات
        /// <summary>
        /// شناسه نوغ تراکنش مالی
        /// </summary>
        //public int FinancialTransactionTypeId { get; set; }
        //===============================================
        /// <summary>
        /// نوع تراکنش مالی
        /// </summary>
        //public virtual FinancialTransactionTypesModel FinancialTransactionType { get; set; }

        //===============================================  
        /// <summary>
        /// شناسه صورتحساب
        /// </summary>
        public int InvoiceId { get; set; }
        //===============================================
        /// <summary>
        /// صورتحساب
        /// </summary>
        public virtual InvoicesModel Invoice { get; set; }

        //===============================================
        /// <summary>
        /// شناسه سفارش
        /// </summary>
        public int? OrderId { get; set; }
        //===============================================
        /// <summary>
        /// سفارش
        /// </summary>
        public virtual OrdersModel Order { get; set; }
    }
}
