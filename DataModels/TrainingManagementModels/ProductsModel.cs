using DataModels.Base;
using DataModels.ContentsModels;
using DataModels.FinancialsModels;
using DataModels.OrdersModels;
using System.Collections;
using System.Collections.Generic;

namespace DataModels.TrainingManagementModels
{
    public class ProductsModel : ModifyDateTimeWithUserModel
    {
        public ProductsModel()
        {
            ProductPromoSections = new HashSet<ProductPromosModel>();
            OrderDetails = new HashSet<OrderDetailsModel>();
            DiscountCodeAcademyProducts = new HashSet<DiscountCodeAcademyProductsModel>();
        }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public int Price { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public int DiscountPercent { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public string PicPath { get; set; }

        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public int DiscountPrice { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public string FilePath { get; set; }
        //=========================================================   ارتباطات 
        /// <summary>
        /// 
        /// </summary>
        public int ProductTypeId { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ProductTypesModel ProductType { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<ProductPromosModel> ProductPromoSections { get; set; }

        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OrderDetailsModel> OrderDetails { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<DiscountCodeAcademyProductsModel> DiscountCodeAcademyProducts { get; set; }

    }
}
