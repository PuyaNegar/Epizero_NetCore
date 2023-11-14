using DataModels.Base;
using DataModels.BasicDefinitionsModels;
using DataModels.FinancialsModels;
using DataModels.OnlineExamModels;
using DataModels.TrainingManagementModels;
using System.Collections;
using System.Collections.Generic;

namespace DataModels.OrdersModels
{
    public class OrderDetailsModel : IdentifierModel
    { 
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public int DiscountCodeAmount { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public string AcademyProductName { get; set;  }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public float DiscountPercent  { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public int Price { get; set; }
        //****************************************************************** ForeginKey 
        /// <summary>
        /// شناسه سفارش 
        /// </summary>
        public int OrderId { get; set; }
        //*******************************************************************
        /// <summary>
        /// سفارش 
        /// </summary>
        public virtual OrdersModel Order { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public int? CourseId { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual CoursesModel Course { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public int? CourseMeetingId { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingsModel CourseMeeting { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public int? OnlineExamId { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual OnlineExamsModel OnlineExams { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public int? ProductId { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual ProductsModel Product { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual  AcademyProductTypesModel AcademyProductType { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public int AcademyProductTypeId { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual SalesPartnerUserSharesModel SalesPartnerShare  { get; set; }
        //*******************************************************************
    }
}
