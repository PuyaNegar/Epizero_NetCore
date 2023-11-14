using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace WebViewModels.ContentsViewModels
{
    public class OldStudentCommentsViewModel
    {
        public int Id { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فبلد {0} نبایستی خالی باشد")]
        public string Tilte { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "متن")]
 
        public string CommentText { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "لینک ویدیو")]
 
        public string CommentVideo { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "لینک صوت")]
 
        public string CommentAudio { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ ثبت ")]
        [Required(ErrorMessage = "فبلد {0} نبایستی خالی باشد")]
        public string RegDateTimeComment { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        public string IsActiveName { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "اولویت نمایش")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int Inx { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دانش آموز")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public int StudentUserId { get; set; }
        public string StudentUserFullName { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع نظر")]
        [Required(ErrorMessage = "فیلد {0} نبایستی خالی باشد")]
        public int CommentTypeId { get; set; }
        public string CommentTypeName { get; set; }
    }
}
