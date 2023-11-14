using System;
using System.Collections.Generic;
using System.Text;
using DataModels.Base;

namespace DataModels.SystemsModels
{
    public class ErrorLogsModel : IdentifierModel
    {
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime OccureDateTime { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public string ErrorSource { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessage { get; set; }
        //=============================================
       
    }
}
