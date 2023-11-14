using DataModels.Base;
using DataModels.IdentitiesModels;
using DataModels.OrdersModels;
using System; 
using System.Collections.Generic;

namespace DataModels.FinancialsModels
{
    public class DiscountCodesModel : ModifyDateTimeWithUserModel
    {
        public DiscountCodesModel()
        {
            DiscountCodeAcademyProducts = new HashSet<DiscountCodeAcademyProductsModel>();
            Orders = new HashSet<OrdersModel>();
        }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; } 
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public string Name  { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public int AmountOrPercent { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsUseableForDiscountAcademyProduct { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public int MaxDiscountAmount { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public int NumberOfTotalUse { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public int NumberOfStudentCanBeUse { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartDate { get; set;  }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime ? EndDate { get; set;  }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public bool? SalePartnerIsPrePayment { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public int? SalePartnerAmountOrPercent { get; set;  }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public string UniqueGuid { get; set; }
        //===================================================================== ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int DiscountCodeTypeId  { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual DiscountCodeTypesModel DiscountCodeType  { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public int? SalePartnerUserId  { get; set; }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel SalePartnerUser { get; set;  }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public int? SalesPartnerShareTypeId  { get; set; } 
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual SalesPartnerShareTypesModel SalesPartnerShareType { get; set;  }
        //============================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<DiscountCodeAcademyProductsModel> DiscountCodeAcademyProducts { get; set; }
        //============================================================

        public virtual  ICollection<OrdersModel> Orders  { get; set; }    
    }
}
