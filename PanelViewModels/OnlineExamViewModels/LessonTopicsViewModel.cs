using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.OnlineExamViewModels
{
   public class LessonTopicsViewModel
    {
        public int Id { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="نام سرفصل")]
        [Required(ErrorMessage = "{0} نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "نام  باید کمتر از {1} کاراکتر باشد")]
        public string Name { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام درس")]
        [Required(ErrorMessage = "{0} نبایستی خالی باشد")]
        public int LessonId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام درس")]
        public string LessonName { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// اولویت نمایش
        /// </summary>
        [Display(Name = "اولویت نمایش")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^\d{0,5}$", ErrorMessage = "فیلد بایستی بصورت عددی و حداکثر 5 رقمی باشد")]
        public int Inx { get; set; }

    }
}
