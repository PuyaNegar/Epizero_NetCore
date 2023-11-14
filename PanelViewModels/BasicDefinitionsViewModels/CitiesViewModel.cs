using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.BasicDefinitionsViewModels
{
    public class CitiesViewModel
    {
        //*******************************************************************
        /// <summary>
        /// شناسه شهر
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
        /// فعال یا غیرفعال
        /// </summary>
        [Display(Name = "وضعيت")]
        public string IsActiveName { get; set; }
        //*******************************************************************
        /// <summary>
        /// نام شهر
        /// </summary>
        [Display(Name = "نام شهر")]
        [Required(ErrorMessage = "فيلد نبايستی خالی باشد")]
        [StringLength(30, ErrorMessage = "نام شهر بایستی حداکثر 30 کاراکتر باشد")]
        public string Name { get; set; }
        //*******************************************************************
        /// <summary>
        /// شناسه استان
        /// </summary>
        [Display(Name = "شناسه استان")]
        public int ProvinceId { get; set; }
        //*******************************************************************
        /// <summary>
        /// نام استان
        /// </summary>
        [Display(Name = "نام استان")]
        public string ProvinceName { get; set; }
    }
}
