using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.FinancialsViewModels
{
    public class PaypingPaymentRequestViewModel
    {
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string payerName { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public int amount { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string payerIdentity { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string returnUrl { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public string clientRefId { get; set; }
        //===================================================
    }
}
