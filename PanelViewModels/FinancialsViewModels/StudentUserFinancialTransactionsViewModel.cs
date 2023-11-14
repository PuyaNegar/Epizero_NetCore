 

namespace PanelViewModels.FinancialsViewModels
{
    public class StudentUserFinancialTransactionsViewModel
    {
        /// <summary>
        /// تاریخ واریز
        /// </summary>
        public string RegDateTime { get; set; }
        //****************************************************************
        /// <summary>
        /// موجودی قبلی
        /// </summary>
        public int PreviousBalance { get; set; }
        //****************************************************************
        /// <summary>
        /// واریز
        /// </summary>
        public int Deposit { get; set; }
        //****************************************************************
        /// <summary>
        /// بـــرداشت
        /// </summary>
        public int Withdraw { get; set; }
        //****************************************************************
        /// <summary>
        /// مانده
        /// </summary>
        public int Balance { get; set; }
        //***************************************************************
        /// <summary>
        /// شناسه سفارش
        /// </summary>
        public string OrderId { get; set; }
        //***************************************************************
        /// <summary>
        /// متد پرداخت
        /// </summary>
        public string FinancialTransactionTypeName { get; set; }
        //***************************************************************
        /// <summary>
        /// شرح تراکنش
        /// </summary>
        public string Comment { get; set; }
        //***************************************************************
        /// <summary>
        /// 
        /// </summary>
        public string InvoiceNo { get; set; }
        //***************************************************************
        /// <summary>
        /// 
        /// </summary>
        public string ModUserFullName { get; set; }
    }
}
