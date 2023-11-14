using System;
using System.Collections.Generic;
using DataModels.Base;
using DataModels.BasicDefinitionsModels;
using DataModels.ContentsModels;
using DataModels.FinancialsModels;
using DataModels.IdentitiesModels;
using DataModels.OrdersModels;
using DataModels.SystemsModels;

namespace DataModels.TrainingManagementModels
{
    public class CoursesModel : ModifyDateTimeWithUserModel
    {
        //===================================================== 
        public CoursesModel()
        {
            CourseStudentNewComments = new HashSet<CourseStudentNewCommentsModel>();
            CommentOldStudentCourses = new HashSet<CommentOldStudentCoursesModel>();
            CourseNotifications = new HashSet<CourseNotificationsModel>();
            CoursePromoSections = new HashSet<CoursePromosModel>();
            CourseMeetings = new HashSet<CourseMeetingsModel>();
            OrderDetails = new HashSet<OrderDetailsModel>();
            CourseSampleVideos = new HashSet<CourseSampleVideosModel>();
            CourseMeetingStudents = new HashSet<CourseMeetingStudentsModel>();
            TeacherPaymentMethods = new HashSet<TeacherPaymentMethodsModel>();
            CourseStudentQuestions = new HashSet<CourseStudentQuestionsModel>();
            DiscountCodeAcademyProducts = new HashSet<DiscountCodeAcademyProductsModel>();
            SalesPartnerUserOptions = new HashSet<SalesPartnerUserOptionsModel>();
            OnlineExamPromos = new HashSet<OnlineExamPromosModel>();
            CourseBooklets = new HashSet<CourseBookletsModel>();
            CourseMultiTeacherShares = new HashSet<CourseMultiTeacherSharesModel>();
            CourseDescriptionVideos = new HashSet<CourseDescriptionVideosModel>();
            CourseFAQs = new HashSet<CourseFAQsModel>();
            ContactUs = new HashSet<ContactUsModel>();
        }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string BannerPicPath { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int Price { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsShowDetailsInWeb { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public float DiscountPercent { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsMultiTeacher { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsVisibleOnSite { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseDuration { get; set; }
        //=====================================================
        /// <summary>
        /// تعداد جلسه
        /// </summary>
        public string CourseMeetingCount { get; set; }
        //=====================================================
        /// <summary>
        ///  مخاطبین
        /// </summary>
        public string Audience { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public int DiscountAmount { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartDate { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndDate { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string LogoPicPath { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary> 
        public string MetaDescription { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public float Inx { get; set; }
        //=================================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int CourseTypeId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseTypesModel CourseTypes { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int TeacherUserId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel TeacherUser { get; set; }
        //=====================================================  
        /// <summary>
        /// 
        /// </summary>
        public int LanguageId { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public virtual LanguagesModel Languages { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CoursePromosModel> CoursePromoSections { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseMeetingsModel> CourseMeetings { get; set; }

        //===================================================== 
        /// <summary>
        /// /
        /// </summary>
        public ICollection<CourseSampleVideosModel> CourseSampleVideos { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public int? LessonId { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public virtual LessonsModel Lessons { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public int? CourseCategoryTypeId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseCategoryTypesModel CourseCategoryType { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OrderDetailsModel> OrderDetails { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseMeetingStudentsModel> CourseMeetingStudents { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<TeacherPaymentMethodsModel> TeacherPaymentMethods { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<CourseStudentQuestionsModel> CourseStudentQuestions { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<DiscountCodeAcademyProductsModel> DiscountCodeAcademyProducts { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<SalesPartnerUserOptionsModel> SalesPartnerUserOptions { get; set; }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OnlineExamPromosModel> OnlineExamPromos { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseBookletsModel> CourseBooklets { get; set; }
        //===========================================================
        /// <summary>
        ///  
        /// </summary>
        public virtual ICollection<CourseMultiTeacherSharesModel> CourseMultiTeacherShares { get; set; }
        //===========================================================
        /// <summary>
        /// CourseDescriptionVideosModel
        /// </summary>
        public virtual ICollection<CourseDescriptionVideosModel> CourseDescriptionVideos { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseNotificationsModel> CourseNotifications { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseFAQsModel> CourseFAQs { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<ContactUsModel> ContactUs { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CommentOldStudentCoursesModel> CommentOldStudentCourses { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseStudentNewCommentsModel> CourseStudentNewComments { get; set; }
    }
}
