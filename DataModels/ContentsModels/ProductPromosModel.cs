using DataModels.Base;
using DataModels.TrainingManagementModels;

namespace DataModels.ContentsModels
{
    public class ProductPromosModel : ModifyDateTimeWithUserModel
    { 
        /// <summary>
        /// اولویت
        /// </summary>
        public int Inx { get; set; }
        //******************************************************************  
        /// <summary>
        /// شناسه قسمت - کليد خارجی
        /// </summary>
        public int ProductPromoSectionId { get; set; }
        //******************************************************************  
        /// <summary>
        /// قسمت - کليد خارجی
        /// </summary>
        public virtual ProductPromoSectionsModel ProductPromoSection { get; set; }
        //******************************************************************
        /// <summary>
        /// شناسه محصول
        /// </summary>
        public int ProductId { get; set; }
        //******************************************************************  
        /// <summary>
        /// محصول - کليد خارجی
        /// </summary>
        public virtual ProductsModel Product { get; set; }
        //******************************************************************
    }
}
