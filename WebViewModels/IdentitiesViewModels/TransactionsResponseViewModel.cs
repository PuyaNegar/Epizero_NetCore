using System.Collections.Generic;

namespace WebViewModels.IdentitiesViewModels
{
    public class TransactionsResponseViewModel
    {
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        public int TotalCount { get; set; }
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        public int Page { get; set; }
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        public List<TransactionsViewModel> Transactions { get; set; }
        //=============================================================================
    }
}
