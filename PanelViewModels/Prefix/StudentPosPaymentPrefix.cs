using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.Prefix
{
    public class StudentPosPaymentPrefix<T> where T : class
    {
        public T StudentPosPayment { get; set; }
    }
}
