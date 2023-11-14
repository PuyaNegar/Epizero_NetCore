using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.Prefix
{
    public class StudentChequePaymentPrefix<T> where T : class
    {
        public T StudentChequePayment { get; set; }
    }
}
