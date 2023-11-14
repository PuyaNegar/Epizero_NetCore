using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class LessonsViewModel
    {
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=======================================================
        /// <summary>
        /// نام درس
        /// </summary>
        [Display(Name = "نام درس")]
        [Required(ErrorMessage = "{0} نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "نام  باید کمتر از {1} کاراکتر باشد")]
        public string Name { get; set; }
        //=======================================================
        /// <summary>
        /// تعداد واحد
        /// </summary>
        [Display(Name = "تعداد واحد")]
        [Required(ErrorMessage = "{0} نبایستی خالی باشد")]
        [Range(1, 4, ErrorMessage = "واحد درسی  1 تا 4 واحد می باشد")]
        public int? UnitCount { get; set; }
        //====================================================================================== ارتباطات 
        /// <summary>
        /// شناسه پایه تحصیلی
        /// </summary>
        [Display(Name = "پایه تحصیلی")]
        [Required(ErrorMessage = "{0} نبایستی خالی باشد")]
        public int? LevelId { get; set; }
        //=======================================================
        /// <summary>
        /// شناسه رشته 
        /// </summary>
        [Display(Name = "رشته تحصیلی")]
        [Required(ErrorMessage = "{0} نبایستی خالی باشد")]
        public int? FieldId { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string LevelName { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        public string FieldName { get; set; }
        //=======================================================
    }
}
