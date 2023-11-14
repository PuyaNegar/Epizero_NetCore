using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.Prefix
{
    public class StudentBankTransferPrefix<T> where T : class
    {
        public T StudentBankTransfer  { get; set; }
    }
}
