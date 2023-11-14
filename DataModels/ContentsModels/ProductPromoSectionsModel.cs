using DataModels.Base; 
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ContentsModels
{
    public class ProductPromoSectionsModel : ModifyDateTimeWithUserModel
    {
        public ProductPromoSectionsModel()
        {
            ProductPromos = new HashSet<ProductPromosModel>();
        } 
        //*******************************************************************
        /// <summary>
        /// اولویت
        /// </summary>
        public int Inx { get; set; }
        //*******************************************************************
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }
        //*******************************************************************
        /// <summary>
        /// فعال بودن
        /// </summary>
        public bool IsActive { get; set; } 
        //****************************************************************** ForeginKey  
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<ProductPromosModel> ProductPromos { get; set; }
    }
}
