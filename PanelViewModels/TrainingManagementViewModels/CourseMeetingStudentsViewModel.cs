using Common.Enums;
using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
    public class CourseMeetingStudentsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=============================================================== 
        /// <summary>
        /// دانش آموز
        /// </summary>
        [Display(Name = "دانش آموز")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
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
        [Display(Name = "جلسه")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int CourseMeetingId { get; set; }
        //===============================================================
        /// <summary>
        /// دانش آموز
        /// </summary>
        [Display(Name = "دانش آموز")]
        public string StudentFullName { get; set; }
        //===============================================================
        /// <summary>
        /// دانش آموز
        /// </summary>
        [Display(Name = "شماره موبایل")]
        public string StudentUserName { get; set; }
        //=============================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دوره")]
        public string CourseName { get; set; }
        //=============================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "جلسه")]
        public string CourseMeetingName { get; set; }
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
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int PaidAmount { get;set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int DiscountAmount  { get; set; }
        //=================================================================
        /// <summary>
        /// مسئول ثبت نام
        /// </summary>
        public string UserEditor { get; set; }
    }
}
