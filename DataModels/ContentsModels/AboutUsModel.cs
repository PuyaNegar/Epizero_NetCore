using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ContentsModels
{
   public class AboutUsModel : ModifyDateTimeWithUserModel
    {
        public string Title { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=--=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        public string SubTitle { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=--=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=--=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        public string BannerPicPath { get; set; }
       
   
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=--=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        public string AltBannerPicPath { get; set; }



        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string CanonicalHref { get; set; }
        public string KeyWordsMetaTag { get; set; }

    }
}
