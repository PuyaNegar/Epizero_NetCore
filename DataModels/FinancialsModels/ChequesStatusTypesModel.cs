using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.FinancialsModels
{
   public class ChequesStatusTypesModel : IdentifierModel
    {
        public ChequesStatusTypesModel()
        {
            PaidCheques = new HashSet<PaidChequesModel>();
        } 
        //===================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        public string NameEN { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<PaidChequesModel> PaidCheques { get; set; }
    }
}
