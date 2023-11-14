using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.IdentitiesViewModels
{
    public class UserLoginLogsViewModel
    {
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        /// 
         public string FullName { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public int DifferentBrowserLoginCount { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public string IsActiveName { get; set; }
    }
}
