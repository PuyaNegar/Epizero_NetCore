using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.IdentitiesViewModels
{
   public class UserRegisterFormViewModel
    {
        public int Id { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "وضعیت")]
        public ActiveStatus IsConfirm { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        public string   IsConfirmName { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام نام خانوادگی")]
        public string FullName { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شماره دانشجویی")]
        public string StudentNo { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
    }
}
