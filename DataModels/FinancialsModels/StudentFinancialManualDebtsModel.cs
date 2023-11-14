using DataModels.Base;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.FinancialsModels
{
   public class StudentFinancialManualDebtsModel : ModifyDateTimeWithUserModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int DebtAmount { get; set; }
        //===============================================
        /// <summary>
        //
        /// </summary>
        public string Description { get; set; }
        //====================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int CourseMeetingStudentId { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingStudentsModel CourseMeetingStudent  { get; set; }
    }
}
