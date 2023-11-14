using System.ComponentModel.DataAnnotations;

namespace WebViewModels.BasicDefinitionsViewModels
{
    public class CitySelectorViewModel
    {
        //===================================================================
        /// <summary>
        /// استان
        /// </summary>
        [Display(Name = "استان")]
        public int ProvinceId { get; set; }
        //===================================================================
        /// <summary>
        /// شهر
        /// </summary>
        [Display(Name = "شهر")]
        public int CityId { get; set; }
        //===================================================================
    }
}
