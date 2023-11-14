using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.Prefix
{
    public class CurrentUserPrefix<T> where T : class
    {
        public T CurrentUser { get; set; }
    }
}
