using DataModels.Base;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using System.Collections.Generic;

namespace DataModels.FinancialsModels
{
    public class StudentFinancialPaymentsModel : ModifyDateTimeWithUserModel
    {
        //==========================================
        public StudentFinancialPaymentsModel()
        {
            //Cheques = new HashSet<StudentChequesModel>();
            StudentPosPayments = new HashSet<StudentPosPaymentsModel>(); 
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// درخواست شماره ارجاع
        /// </summary>
        public string RequestReferenceNumber { get; set; }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public int AmountPaid { get; set; }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentFinancialPaymentTypeId { get; set; }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public virtual StudentFinancialPaymentTypesModel StudentFinancialPaymentType { get; set; }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId  { get; set; }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel StudentUser { get; set; }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        //public virtual ICollection<StudentChequesModel> Cheques { get; set; }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StudentPosPaymentsModel> StudentPosPayments { get; set; }
        //====================================================== ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int? CourseMeetingStudentId { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingStudentsModel CourseMeetingStudent { get; set; }
        //======================================================

    }
}
