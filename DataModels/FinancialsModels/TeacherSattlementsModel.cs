using System;

namespace DataModels.FinancialsModels
{
    public class TeacherSattlementsModel 
    {

        public int Id { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public long SettledAmount { get; set; }
        //============================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int TeacherSattlementScheduleId { get; set; }
        //==============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual TeacherSattlementSchedulesModel TeacherSattlementSchedules { get; set; }
    }
}
