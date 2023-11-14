using DataModels.Base;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.FinancialsModels
{
   public class StudentFinancialDebtsModel : ModifyDateTimeWithUserModel
    {
        /// <summary>
        /// 
        /// </summary>
         public bool IsCanceled { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseMeetingStudentId { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public string DiscountDiscription { get; set; }
        //=======================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingStudentsModel CourseMeetingStudent { get; set; }
    }
}
