using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.BaseViewModels
{
   public class MultiChartsViewModel<T>
    {
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public List<string> Titles { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public List<ChartsViewModel<T>> Values { get; set; }
        //===============================================
    }
}
