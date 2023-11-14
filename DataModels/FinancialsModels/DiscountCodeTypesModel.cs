using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.FinancialsModels
{
    public class DiscountCodeTypesModel : IdentifierModel
    {
        public DiscountCodeTypesModel()
        {
            DiscountCodes = new HashSet<DiscountCodesModel>(); 
        }
        //====================================================
        ///<summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string NameEN { get; set; }
        //====================================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<DiscountCodesModel> DiscountCodes { get; set; }
    }
}
