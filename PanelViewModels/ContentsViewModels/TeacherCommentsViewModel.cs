using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.ContentsViewModels
{
    public class TeacherCommentsViewModel
    {
        //======================================
        /// <summary>
        /// شناسه نظر
        /// </summary>
        public int Id { get; set; }
        //======================================
        /// <summary>
        /// متن نظر
        /// </summary>
        [Display(Name = "متن نظر")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(2000, ErrorMessage = "عنوان بایستی حداکثر 2000 کاراکتر باشد")]
        public string Comment { get; set; }
        //======================================
        /// <summary>
        /// تاریخ درج نظر
        /// </summary>
        [Display(Name = "تاریخ درج نظر")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public string RegDateTime { get; set; }
        //======================================
        /// <summary>
        /// تاریخ ویرایش نظر
        /// </summary>
        [Display(Name = "تاریخ ویرایش نظر")]
        public string ModDateTime { get; set; }
        //======================================
        /// <summary>
        /// تاریخ تایید نظر
        /// </summary>
        [Display(Name = "تاریخ تایید نظر")]
        public string ConfirmedDateTime { get; set; }
        //======================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        //[Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        //[Display(Name = "وضعیت")]
        //public ActiveStatus IsActive { get; set; }
        //=======================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        public string IsActiveName { get; set; }
        //======================================
        /// <summary>
        /// تایید یا رد
        /// </summary>
        //[Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        [Display(Name = "تایید یا رد")]
        public ActiveStatus? IsConfirmed { get; set; }
        //=======================================
        /// <summary>
        /// تایید یا رد
        /// </summary>
        public string IsConfirmedName { get; set; }
        //=======================================
        /// <summary>
        /// شناسه دبیر
        /// </summary>
        public int TeacherUserId { get; set; }
        //=======================================
        /// <summary>
        /// نام دبیر
        /// </summary>
        [Display(Name = "نام دبیر")]
        public string TeacherUserName { get; set; }
        //=======================================
        /// <summary>
        /// شناسه مشتری
        /// </summary>
        public int  StudentUserId { get; set; }
        //=======================================
        /// <summary>
        /// نام مشتری
        /// </summary>
        [Display(Name = "نام دانش آموز")]
        public string StudentUserName { get; set; }
        //=======================================
        /// <summary>
        /// شناسه اپراتور
        /// </summary>
        public int ModUserrId { get; set; }
        //=======================================
        /// <summary>
        /// نام اپراتور
        /// </summary>
        [Display(Name = "نام اپراتور")]
        public string ModUserName { get; set; }
    }
}
