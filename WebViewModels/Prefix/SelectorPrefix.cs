using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.Prefix
{
    public class SelectorPrefix<T> where T : class
    {
        public T Selector { get; set; }
    }
}
