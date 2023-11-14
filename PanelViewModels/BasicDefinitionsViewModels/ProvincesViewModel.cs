using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.BasicDefinitionsViewModels
{
    public class ProvincesViewModel
    {
        /// <summary>
        /// شناسه استان
        /// </summary>
        public int Id { get; set; }
        //*******************************************************************
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        [Display(Name = "وضعيت")]
        public ActiveStatus IsActive { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public string IsActiveName { get; set; }
        //*******************************************************************
        /// <summary>
        /// نام استان
        /// </summary>
        [Display(Name = "نام استان")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        [StringLength(50, ErrorMessage = " بایستی حداکثر 50 کاراکتر باشد ")]
        public string Name { get; set; }
    }
}
