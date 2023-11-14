using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.Prefix
{
    public class StudentCashPaymentPrefix<T> where T : class
    {
        public T StudentCashPayment  { get; set; }
    }
}
