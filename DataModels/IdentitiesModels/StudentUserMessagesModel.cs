using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.IdentitiesModels
{
   public class StudentUserMessagesModel 
    {
        public int Id { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsAnswered { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public string QuestionText { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public string AnsweredQuestionText { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AnsweredDateTime { get; set; }
        //=============================================================
        /// <summary>
        /// تاریخ تغییر
        /// </summary>
        public DateTime? ModDateTime { get; set; }
        //=============================================================
        /// <summary>
        /// تاریخ درج
        /// </summary>
        public DateTime RegDateTime { get; set; }
        //=============================================================
        /// <summary>
        ///  
        /// </summary>
        public int StudentUserId { get; set; }
        //=============================================================
        /// <summary>
        ///  
        /// </summary>
        public virtual UsersModel StudentUser { get; set; }
        //=============================================================
        /// <summary>
        /// شناسه ویرایش کننده
        /// </summary>
        public int? ModUserId { get; set; }
        //=============================================================
        /// <summary>
        /// ویرایش کننده
        /// </summary>
        public virtual UsersModel ModUser { get; set; }
    }
}
