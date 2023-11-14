using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace TeacherViewModels.TraningsViewModels
{
    public class TeacherHomeworksViewModel
    {
        public int Id { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "عنوان نبایستی خالی باشد")]
        [StringLength(200, ErrorMessage = "عنوان باید کمتر از {1} کاراکتر باشد")]
        public string Title { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "جلسات دوره")]
        [Required(ErrorMessage = "شناسه جلسات دوره نبايستی خالی باشد")]
        public int CourseMeetingId { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "جلسات دوره")]
        public string CourseMeetingName { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "تاریخ منقضی نبايستی خالی باشد")]
        [Display(Name = "تاریخ منقضی ")]
        public string ExpiredDate { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ ثبت")]
        public string RegDateTime { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "فایل تکلیف")]
        public string FilePath { get; set; }
        //============================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        [Display(Name = "وضعيت")]
        [Required(ErrorMessage = "وضعيت نبايستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string IsActiveName { get; set; }
    }
}
