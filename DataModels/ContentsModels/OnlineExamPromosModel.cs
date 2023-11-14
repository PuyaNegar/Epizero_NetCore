﻿using DataModels.Base;
using DataModels.TrainingManagementModels;

namespace DataModels.ContentsModels
{
    public class OnlineExamPromosModel : ModifyDateTimeWithUserModel
    { 
        /// <summary>
        /// اولویت
        /// </summary>
        public int Inx { get; set; }
        //******************************************************************  
        /// <summary>
        /// شناسه قسمت - کليد خارجی
        /// </summary>
        public int OnlineExamPromoSectionId { get; set; }
        //******************************************************************  
        /// <summary>
        /// قسمت - کليد خارجی
        /// </summary>
        public virtual OnlineExamPromoSectionsModel OnlineExamPromoSection { get; set; }
        //******************************************************************
        /// <summary>
        /// شناسه محصول
        /// </summary>
        public int CourseId { get; set; }
        //******************************************************************  
        /// <summary>
        /// محصول - کليد خارجی
        /// </summary>
        public virtual CoursesModel Course  { get; set; }
        //******************************************************************
    }
}
