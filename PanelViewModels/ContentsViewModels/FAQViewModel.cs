using System.ComponentModel.DataAnnotations;
using Common.Enums;

namespace PanelViewModels.ContentsViewModels
{
    public class FAQViewModel
    {
        //============================================
        /// <summary>
        /// شناسه اسلایدر
        /// </summary>
        public int Id { get; set; }
        //============================================
        /// <summary>
        /// اولویت نمایش
        /// </summary>
        [Display(Name = "سوال")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")] 
        public string QuestionContext { get; set; } 
        //============================================
        /// <summary>
        /// عنوان
        /// </summary>
        [Display(Name = "پاسخ")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")] 
        public string AnswerContext { get; set; } 
        //============================================
        /// <summary>
        /// لینک URL
        /// </summary>
        [Display(Name = "اولویت نمایش")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int Inx { get; set; }
        //=========================================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }

        //=========================================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        public string IsActiveName { get; set; }
        //=========================================================
         
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "آیادر سایت نمایش داده شود؟")]
        public ActiveStatus IsWebSite { get; set; }
        //=====================================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        public string IsWebSiteName { get; set; }
        //=====================================================
    }
}
