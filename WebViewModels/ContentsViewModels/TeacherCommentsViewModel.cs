using DataModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebViewModels.ContentsViewModels
{
    public class TeacherCommentsViewModel : ModifyDateTimeWithUserModel
    {
        [Required(ErrorMessage = "نظر خود را وارد کنید")]
        [MaxLength(2000, ErrorMessage = "نظر کوتاه تری وارد کنید")]
        public string Comment { get; set; }
        public DateTime ConfirmedDateTime { get; set; }
        //public bool IsActive { get; set; }
        public bool? IsConfirmed { get; set; }
        public int StudentUserId { get; set; }
        public string StudentUserFullName { get; set; }
        public string StringConfirmedDateTime { get; set; }
        public int TeacherUserId { get; set; }
    }
}
