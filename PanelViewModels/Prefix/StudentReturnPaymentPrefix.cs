using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.Prefix
{
    public class StudentReturnPaymentPrefix<T> where T : class
    {
        public T StudentReturnPayment { get; set; }
    }
}
