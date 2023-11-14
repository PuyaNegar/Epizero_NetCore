using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.Prefix
{
    public class StatusPrefix<T> where T : class
    {
        public T Status { get; set; }
    }
}
