using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.Prefix
{
     public class ManualDebtsPrefix<T> where T : class
    {
        public T ManualDebts { get; set; }
    }
}
