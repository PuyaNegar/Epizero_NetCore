using DataModels.Base;
using DataModels.FinancialsModels;
using DataModels.IdentitiesModels;
using DataModels.OnlineExamModels;
using DataModels.OrdersModels;
using System.Collections.Generic;

namespace DataModels.TrainingManagementModels
{
    public class CourseMeetingStudentsModel : ModifyDateTimeWithUserModel
    {
        public CourseMeetingStudentsModel()
        { 
            StudentFines = new HashSet<StudentFinesModel>();
            StudentFinancialPayments  = new HashSet<StudentFinancialPaymentsModel>();
            StudentFinancialReturnPayments = new HashSet<StudentFinancialReturnPaymentsModel>();
            StudentPaymentLinks = new HashSet<StudentPaymentLinksModel>();
            StudentFinancialManualDebts = new HashSet<StudentFinancialManualDebtsModel>();
        }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsOnlineRegistrated { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public int SalePartnerPrice { get; set;  }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public int RawPrice { get; set;  }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public int Price { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        public int DiscountAmount { get; set; }
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        //public virtual OnlineExamStudentsModel OnlineExamStudent { get; set; }
        //================================================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int? CourseMeetingId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingsModel CourseMeeting { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel StudentUsers { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CoursesModel Course { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseMeetingStudentTypeId { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public bool IsTemporaryRegistration { get; set;  }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingStudentTypesModel CourseMeetingStudentType { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int? OrderId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual OrdersModel Order { get; set; }
        //=====================================================
        /// <summary>
        ///    
        /// </summary>
        public virtual StudentFinancialDebtsModel StudentFinancialDebts { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StudentFinesModel> StudentFines { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StudentFinancialPaymentsModel> StudentFinancialPayments { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StudentFinancialReturnPaymentsModel>  StudentFinancialReturnPayments { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StudentPaymentLinksModel> StudentPaymentLinks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StudentFinancialManualDebtsModel> StudentFinancialManualDebts { get; set; }

    }
}
