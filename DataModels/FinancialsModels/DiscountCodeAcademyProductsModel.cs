using DataModels.Base;
using DataModels.BasicDefinitionsModels;
using DataModels.OnlineExamModels;
using DataModels.TrainingManagementModels;

namespace DataModels.FinancialsModels
{
   public class DiscountCodeAcademyProductsModel : ModifyDateTimeWithUserModel
    {
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public int? CourseId { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual CoursesModel Course { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public int? CourseMeetingId { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual CourseMeetingsModel CourseMeeting { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public int? OnlineExamId { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual OnlineExamsModel OnlineExams { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public int? ProductId { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual ProductsModel Product { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual AcademyProductTypesModel AcademyProductType { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public int AcademyProductTypeId { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public int DiscountCodeId { get; set;  }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual DiscountCodesModel DiscountCode  { get; set; }
        //*******************************************************************

    }
}
