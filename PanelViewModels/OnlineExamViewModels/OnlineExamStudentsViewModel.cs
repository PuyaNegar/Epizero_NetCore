using Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.OnlineExamsViewModels
{
    public class OnlineExamStudentsViewModel
    {
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentFullName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int OnlineExamId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<int> StudentUserIds { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string IsFinalizedName { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
         public string  IsAbsentOnMainTimeName  {get;set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string EnterDateTime { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public bool IsFinalized { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public bool HasEnterDateTime { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string StartDateTimeOnlineExam { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string OnlineExamName { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public bool IsExpired { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public int TotalRank { get; set; }
    }
}
