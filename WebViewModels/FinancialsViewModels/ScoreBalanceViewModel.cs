using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.FinancialsViewModels
{
    public class ScoreBalanceViewModel
    {
        //========================================================================
        /// <summary>
        /// شناسه مشتری
        /// </summary>
        public int StudentUserId { get; set; }
        //========================================================================
        /// <summary>
        /// موجودی کیف پول
        /// </summary>
        public int Balance { get; set; }
        //========================================================================
    }
}
