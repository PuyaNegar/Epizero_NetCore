using DataModels.Base; 
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ContentsModels
{
    public class CoursePromoSectionsModel : ModifyDateTimeWithUserModel
    {
        public CoursePromoSectionsModel()
        {
            CoursePromos = new HashSet<CoursePromosModel>();
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
        public virtual ICollection<CoursePromosModel> CoursePromos { get; set; }
    }
}
