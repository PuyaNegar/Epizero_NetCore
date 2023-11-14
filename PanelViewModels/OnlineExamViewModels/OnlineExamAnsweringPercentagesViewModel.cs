using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.OnlineExamViewModels
{
    public class OnlineExamAnsweringPercentagesViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int QuestionId  { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
       // public int TrueAnsweredCount { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        //public int FalseAnsweredCount { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        //public int NoAnsweredCount { get; set;  }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public decimal TrueAnsweredPercent { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public decimal FalseAnsweredPercent { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public decimal NoAnsweredPercent { get; set; }

    }
}
