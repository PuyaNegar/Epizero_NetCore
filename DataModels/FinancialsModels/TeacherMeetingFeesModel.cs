using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.FinancialsModels
{
    public class TeacherMeetingFeesModel
    {
        public int Id { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public int Fee { get; set; }
        //=============================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int TeacherPaymentMethodId { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual TeacherPaymentMethodsModel TeacherPaymentMethod { get; set; }
    }
}
