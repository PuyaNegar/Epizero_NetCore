using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.ContentsViewModels
{
    public class AcceptedStudentInEntranceExamsViewModel
    {
        public int Id { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع مدال")]
        public int? OlympiadMedalTypeId { get; set; }

        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string OlympiadMedalTypeName { get; set;  }
        //========================================================
        /// <summary>
        /// 
        /// </summary>
        public string EntranceExamTypeName  { get; set;  } 
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع آزمون")]
        [Required(ErrorMessage = "فبلد {0} نبایستی خالی باشد")]
        public int EntranceExamTypeId { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات")]
        [StringLength(2000, ErrorMessage = "فیلد نبایستی بیشتر از 2000 کاراکتر باشد")]
        public string Description { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام کامل دانش آموز")]
        [Required(ErrorMessage = "فبلد {0} نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "فیلد نبایستی بیشتر از 100 کاراکتر باشد")]
        public string StudentFullName { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public int TeacherUserId { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "فبلد {0} نبایستی خالی باشد")]
        public string PicPath { get; set; }
    }
}
