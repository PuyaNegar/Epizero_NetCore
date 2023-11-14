using DataModels.Base;
using DataModels.FinancialsModels;
using DataModels.IdentitiesModels;
using DataModels.OrdersModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;

namespace DataModels.OnlineExamModels
{
    public class OnlineExamsModel : ModifyDateTimeWithUserModel
    {
        public OnlineExamsModel()
        {
            OnlineExamQuestions = new HashSet<OnlineExamQuestionsModel>();
            CourseMeetingOnlineExams = new HashSet<CourseMeetingOnlineExamsModel>();
            OrderDetails = new HashSet<OrderDetailsModel>();
            DiscountCodeAcademyProducts = new HashSet<DiscountCodeAcademyProductsModel>();
            OnlineExamAnalysises = new HashSet<OnlineExamAnalysisModel>();
            OnlineExamFields = new HashSet<OnlineExamFieldsModel>();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public bool IsVisibleOnSite { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartDateTime { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public int Duration { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public int? AllowedTimeToEnter { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public bool IsRandomQuestions { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public bool IsRandomOption { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public bool HasNegativePoint { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public int MaxGrade { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public string AnalysisVideoLink { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public int TeacherUserId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public bool IsAbleToEnterExpiredExam { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public bool IsAvailableForSpecificFields { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel TeacherUser { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=  ارتباطات  
        /// <summary>
        /// 
        /// </summary>
        public int? CourseMeetingId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingsModel CourseMeeting { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public int OnlineExamTypeId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public virtual OnlineExamTypesModel OnlineExamType { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=  
        /// <summary>
        /// 
        /// </summary>
        public int QuestionTypeId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public virtual QuestionTypesModel QuestionType { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OnlineExamQuestionsModel> OnlineExamQuestions { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=  
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseMeetingOnlineExamsModel> CourseMeetingOnlineExams { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OrderDetailsModel> OrderDetails { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        //=======================================================
        public virtual ICollection<DiscountCodeAcademyProductsModel> DiscountCodeAcademyProducts { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public virtual ICollection<OnlineExamAnalysisModel> OnlineExamAnalysises { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OnlineExamFieldsModel> OnlineExamFields { get; set; }
    }
}
