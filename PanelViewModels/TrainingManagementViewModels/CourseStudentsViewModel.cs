using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.TrainingManagementViewModels
{
    public class CourseStudentsViewModel
    {
        //=============================================================== 
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=============================================================== 
        /// <summary>
        /// دانش آموز
        /// </summary>
        [Display(Name = "نام")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public string StudentUserIds { get; set; }
        //=============================================================== 
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //=============================================================== 
        /// <summary>
        /// کلاس
        /// </summary>
        [Display(Name = "دوره")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public int CourseId { get; set; }
        //===============================================================
        /// <summary>
        /// دانش آموز
        /// </summary>
        [Display(Name = "نام نام خانوادگی")]
        public string StudentFullName { get; set; }
  
        //===============================================================
        /// <summary>
        /// نام رشته
        /// </summary>
        [Display(Name = "نام رشته")]
        public string FieldName { get; set; }
        //===============================================================
        /// <summary>
        /// کلاس
        /// </summary>
        [Display(Name = "دوره")]
        public string CourseName { get; set; }
        //===============================================================  
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public string IsOnlineRegistratedName { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public string IsTemporaryRegistrationName { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int PaidAmount { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int DiscountAmount { get; set; }
        //===============================================================
 
        /// <summary>
        /// مسئول ثبت نام
        /// </summary>
        public string UserEditor { get; set; }
    }
}
