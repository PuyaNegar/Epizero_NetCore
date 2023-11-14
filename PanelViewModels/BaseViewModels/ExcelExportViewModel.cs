using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.BaseViewModels
{
    public class ExcelExportViewModel
    {
        //=============================================================
        /// <summary>
        /// نام کامل مدیر
        /// </summary>
        public string FileName { get; set; }
        //=============================================================
        /// <summary>
        /// محتوای باینری اکسل
        /// </summary>
        public byte[] FileContents { get; set; }
        //=============================================================
    }
}
