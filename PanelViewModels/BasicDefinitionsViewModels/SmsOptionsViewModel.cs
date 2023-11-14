using Common.Enums; 
using System.ComponentModel.DataAnnotations;
  
namespace PanelViewModels.BasicDefinitionsViewModels
{
  public class SmsOptionsViewModel
    {
        public int Id { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        [StringLength(50, ErrorMessage = " بایستی حداکثر 50 کاراکتر باشد ")]
        public string Title { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [Display(Name = "مبلغ (تومان)")]
        public int Price { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        [Display(Name = "وضعيت")]
        public ActiveStatus IsActive { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "وضعيت")]
        public string IsActiveName { get; set; }
    }
}
