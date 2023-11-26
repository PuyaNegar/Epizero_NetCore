using DataModels.Base;
using DataModels.FinancialsModels;
using DataModels.HomeworksModels;
using DataModels.IdentitiesModels;
using DataModels.OnlineExamModels;
using DataModels.OrdersModels;
using DataModels.SystemsModels;
using System;
using System.Collections.Generic;

namespace DataModels.TrainingManagementModels
{
    public class CourseMeetingsModel : ModifyDateTimeWithUserModel
    {
        public CourseMeetingsModel()
        {
            Homeworks = new HashSet<HomeworksModel>();
            CourseMeetingBooklet = new HashSet<CourseMeetingBookletsModel>();
            CourseMeetingVideos = new HashSet<CourseMeetingVideosModel>();
            CourseMeetingStudents = new HashSet<CourseMeetingStudentsModel>();
            OrderDetails = new HashSet<OrderDetailsModel>(); 
            MeetingAbsentations = new HashSet<MeetingAbsentationsModel>();
            OnlineClasses = new HashSet<OnlineClassesModel>();
            DiscountCodeAcademyProducts = new HashSet<DiscountCodeAcademyProductsModel>();
            Absentations = new HashSet<AbsentationsModel>(); 
        }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public int Price { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public float DiscountPercent { get; set;  }
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
        public bool IsPurchasable { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool HasExam { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
         public int DiscountAmount { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary> 
        public bool IsActive { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartDateTime { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public int Inx { get; set; }
        //======================================================= ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int TeacherUserId { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel TeacherUser { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseId { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CoursesModel Course { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual OnlineExamsModel OnlineExam { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<HomeworksModel> Homeworks { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseMeetingVideosModel> CourseMeetingVideos { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseMeetingBookletsModel> CourseMeetingBooklet { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseMeetingStudentsModel> CourseMeetingStudents { get; set;  }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseMeetingOnlineExamsModel> CourseMeetingOnlineExams { get; set;  }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OrderDetailsModel> OrderDetails { get; set;  } 
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<MeetingAbsentationsModel> MeetingAbsentations { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OnlineClassesModel> OnlineClasses { get; set;  }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<DiscountCodeAcademyProductsModel> DiscountCodeAcademyProducts { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<AbsentationsModel> Absentations { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingDedicatedTeachersModel CourseMeetingDedicatedTeacher { get; set; }
        //=======================================================

    }
}
