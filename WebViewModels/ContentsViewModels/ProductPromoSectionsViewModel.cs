using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.ContentsViewModels
{
    public class ProductPromoSectionsViewModel
    {
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        //=====================================================================
        /// <summary>
        /// اولویت
        /// </summary>
        [JsonIgnore]
        public int Inx { get; set; }
        //=====================================================================
        /// <summary>
        /// لیست محصولات تبلیغاتی
        /// </summary>
        public List<ProductPromsViewModel> ProductProms  { get; set; }
        //=====================================================================
    }
}
