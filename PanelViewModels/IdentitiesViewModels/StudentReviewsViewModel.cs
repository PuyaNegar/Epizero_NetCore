using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.IdentitiesViewModels
{
   public class StudentReviewsViewModel
    {
        public int Id { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "در سایت مشاهده شود؟")]
        [Required(ErrorMessage = "{0} نبایستی خالی باشد")]
        public ActiveStatus IsVisible { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "در سایت مشاهده شود؟")]
        public string IsVisibleName { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "وضعیت تایید")]
        [Required(ErrorMessage = "{0} نبایستی خالی باشد")]
        public ActiveStatus IsVerify { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "وضعیت تایید")]
        public string IsVerifyName { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "متن نظر")]
        public string Comment { get; set; }
        //=======================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ درج خبر")]
        public string RegDateTime { get; set; }
        //=======================================================
    }
}
