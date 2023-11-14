using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.OnlineExamsViewModels
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
        //====================================================================================== ارتباطات 
    }
}
