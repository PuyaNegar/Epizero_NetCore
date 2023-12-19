using System;
using System.Collections.Generic;
using System.Text;
using WebViewModels.ContentsViewModels;

namespace WebViewModels.TrainingsViewModels
{
   public class CourseMeetingsViewModel
    {
        public int Inx { get; set; }
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CourseId { get; set; }
        //=========================================================
        /// <summary>
        /// دوره
        /// </summary>
        public string CourseName { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int Price { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string StartDateTime { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string EndDateTime { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartDateTimeOrginal { get; set; }
        //===================================================== 
        /// <summary>
        ///  
        /// </summary>
        public int DiscountPrice { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public bool HasBooklet { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool HasHomework { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool HasExam { get; set; }
        //=====================================================
        /// <summary>
        /// شروع
        /// </summary>
        public bool IsStarted { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsPurchasable { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string TeacherFullName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsAbleToViewOrBuy { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int? OnlineExamId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseDuration { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsShowQuestionAnswer { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string AnalysisVideoLink { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsAvailableForSpecificFields { get; set;  }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string NumberQuestions { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<int> OnlineExamFieldIds { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public CourseDedicatedTeachersViewModel CourseDedicatedTeacher { get; set; }
        //=====================================================
    }
}
