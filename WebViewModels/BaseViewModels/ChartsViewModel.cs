using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.BaseViewModels
{
   public class ChartsViewModel<T>
    {
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public List<T> Values { get; set; }
        //==========================================
    }
}
