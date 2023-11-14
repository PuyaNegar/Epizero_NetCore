using DataModels.Base; 
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ContentsModels
{
    public class OnlineExamPromoSectionsModel : ModifyDateTimeWithUserModel
    {
        public OnlineExamPromoSectionsModel()
        {
            OnlineExamPromos = new HashSet<OnlineExamPromosModel>();
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
        public virtual ICollection<OnlineExamPromosModel> OnlineExamPromos { get; set; }
    }
}
