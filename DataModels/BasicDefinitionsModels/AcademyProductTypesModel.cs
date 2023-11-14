using DataModels.Base;
using DataModels.FinancialsModels;
using DataModels.OrdersModels; 
using System.Collections.Generic;
 

namespace DataModels.BasicDefinitionsModels
{
   public class AcademyProductTypesModel : IdentifierModel
    {
        public AcademyProductTypesModel()
        {
            OrderDetails = new HashSet<OrderDetailsModel>();
            DiscountCodeAcademyProducts = new HashSet<DiscountCodeAcademyProductsModel>(); 
        }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public string NameEn { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection< OrderDetailsModel > OrderDetails { get; set;  }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<DiscountCodeAcademyProductsModel> DiscountCodeAcademyProducts { get; set; }
    }
}
