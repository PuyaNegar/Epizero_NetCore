using PanelViewModels.OnlineExamsViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.OnlineExamViewModels
{
   public class StudentOnlineExamResultGroupsViewModel
    {
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentFullName { get; set; }
        //===========================================
        /// <summary>
        /// رتبه کل
        /// </summary>
        public int TotalRank { get; set;  }
        //===========================================
        /// <summary>
        /// نمره کل
        /// </summary>
        public float TotalScore { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public string SchoolName { get; set;  }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public string CityName { get; set;  }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public int? FieldId { get; set;  }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public int CityId { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalBalance { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsAbsentOnMainTime { get; set; }
        //===========================================
        /// <summary>
        /// 
        /// </summary>

        public List<StudentOnlineExamResultsViewModel> StudentOnlineExamResults { get; set; }
    }
}
