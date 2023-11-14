using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.IdentitiesViewModels
{
    public class UserMessagesViewModel
    {
        public int Id { get; set; }
        public string RegDateTime { get; set; }
        public string ReadDateTime { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
