using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.FinancialsViewModels
{
    public class BalanceViewModel
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
