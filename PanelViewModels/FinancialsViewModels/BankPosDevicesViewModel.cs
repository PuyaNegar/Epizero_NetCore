using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.FinancialsViewModels
{
   public class BankPosDevicesViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "شماره حساب")]
        [Required(ErrorMessage = "شماره حساب را وارد کنید")]
        public string AccountNo { get; set; }
        //===================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        //===================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام بانک")]
        [Required(ErrorMessage = "نام بانک را وارد کنید")]
        public int BankId { get; set; }
        //===================================================================== 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام بانک")]
        public string BankName { get; set; }
    }
}
