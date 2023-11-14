using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.FinancialsViewModels
{
    public class SepehrTokenCreateRequestDTOModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string CallbackUrl { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public string InvoiceId { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public string Payload { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public string TerminalId { get; set; }
        //=================================================
        
        public long Amount { get; set; }
    }
}
