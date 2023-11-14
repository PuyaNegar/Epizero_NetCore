using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.ContentsViewModels
{
    public class AboutUsViewModel
    {
        //=====================================================
        /// <summary>
        /// شناسه
        /// </summary>
        public int Id { get; set; }
        //=====================================================
        /// <summary>
        /// عنوان
        /// </summary>
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فبلد {0} نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "فیلد نبایستی بیشتر از 100 کاراکتر باشد")]
        public string Title { get; set; }
        //=====================================================
        /// <summary>
        /// عنوان
        /// </summary>
        [Display(Name = "زیر عنوان")]
        [Required(ErrorMessage = "فبلد {0} نبایستی خالی باشد")]
        [StringLength(3000, ErrorMessage = "فیلد نبایستی بیشتر از 3000 کاراکتر باشد")]
        public string SubTitle { get; set; }
        //=====================================================
        /// <summary>
        /// متن
        /// </summary>
        [Display(Name = "متن")]
        //[Required(ErrorMessage = "فبلد {0} نبایستی خالی باشد")]
        public string Description { get; set; }
  
        //=====================================================
        /// <summary>
        /// تصویر
        /// </summary>
        [Display(Name = "بنر درباره ما")]
        [Required(ErrorMessage = "تصویر نبایستی خالی باشد")]
        public string BannerPicPath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "متن ارسالی پیامک از دستگاه دایرکت")]
        public string DirectDeviceSmsMessage { get; set; }




        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "متا دیسکریپشن")]
        public string MetaDescription { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "متا تایتل")]
        public string MetaTitle { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "کانونیکال href")]
        public string CanonicalHref { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "کلمات کلیدی در متا تگ")]
        public string KeyWordsMetaTag { get; set; }


        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=--=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Alt تصویر بنر")]
 
        public string AltBannerPicPath { get; set; }
        

    }
}
