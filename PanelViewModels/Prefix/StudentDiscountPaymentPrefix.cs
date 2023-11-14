using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.Prefix
{
    public class StudentDiscountPaymentPrefix<T> where T : class
    {
        public T StudentDiscountPayment { get; set; }
    }
}
