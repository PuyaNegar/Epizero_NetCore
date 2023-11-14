using DataModels.Base; 
using System.Collections.Generic;

namespace DataModels.TrainingManagementModels
{
    public class ProductTypesModel : ModifyDateTimeWithUserModel
    {
        public ProductTypesModel()
        {
            Products = new HashSet<ProductsModel>();
        }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<ProductsModel> Products { get; set;  }
    }
}
