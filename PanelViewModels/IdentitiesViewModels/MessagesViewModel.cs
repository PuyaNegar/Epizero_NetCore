using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.IdentitiesViewModels
{
   public class MessagesViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(200, ErrorMessage = "عنوان بایستی حداکثر 20۰ کاراکتر باشد")]
        public string Title { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "متن پیام")]
        //[Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public string Message { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع پیام")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int MessageTypeId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نوع پیام")]
        public string MessageTypeName { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "کاربران دریافت کننده")]
        public List<int> ReceiverUsersId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "کاربران دریافت کننده")]
        public List<string> ReceiverUserIds { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// شناسه تگ‌های محصول
        /// </summary>
        [Display(Name = "تگ‌های پیام")]
        public List<string> MessageTagsId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// شناسه تگ‌های محصول
        /// </summary>
        [Display(Name = "تعداد کاربران دریافت کننده پیامک")]
        public string StudentRecivedMessageCount { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// شناسه تگ‌های محصول
        /// </summary>
        [Display(Name = "تگ ها")]
        public string TagsName { get; set; }
    }
}
