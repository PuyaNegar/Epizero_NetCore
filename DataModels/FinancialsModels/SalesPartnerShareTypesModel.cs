using DataModels.Base; 
using System.Collections.Generic;
  
namespace DataModels.FinancialsModels
{
   public class SalesPartnerShareTypesModel : IdentifierModel
    {
        public SalesPartnerShareTypesModel()
        {
            DiscountCodes = new HashSet<DiscountCodesModel>(); 
        }
        //==================================
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
        public ICollection<DiscountCodesModel> DiscountCodes { get; set; }
        //===================================
    }
}
