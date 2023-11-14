using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.Prefix
{
     public class StudentFinesPrefix<T> where T : class
    {
        public T StudentFines { get; set; }
    }
}
