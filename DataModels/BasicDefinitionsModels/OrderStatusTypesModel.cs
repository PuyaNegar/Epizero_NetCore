using DataModels.Base;
using DataModels.OrdersModels;
using System.Collections.Generic;

namespace DataModels.BasicDefinitionsModels
{
    public class OrderStatusTypesModel : IdentifierModel
    {
        public OrderStatusTypesModel()
        {
             this.Orders = new HashSet<OrdersModel>();
        } 
        //*******************************************************************
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; } 
        //*******************************************************************
        /// <summary>
        /// عنوان لاتین
        /// </summary>
        public string TitleEN { get; set; } 
        //******************************************************************* ForeginKey 
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OrdersModel> Orders { get; set; }
        //*******************************************************************
    }
}
