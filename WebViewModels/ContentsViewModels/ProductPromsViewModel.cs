
namespace WebViewModels.ContentsViewModels
{
    public class ProductPromsViewModel
    {
        //========================================================================
        /// <summary>
        /// شناسه
        /// </summary>
        public int Id { get; set; }
        //========================================================================
        /// <summary>
        /// لینک عکس محصول
        /// </summary>
        public string  PicPath { get; set; }
        //========================================================================
        /// <summary>
        /// نام محصول
        /// </summary>
        public string Name { get; set; }
        //========================================================================
        /// <summary>
        /// درصد تخفیف
        /// </summary>
        public int DiscountPrice { get; set; }
        //========================================================================
        /// <summary>
        /// مبلغ
        /// </summary>
        public int Price { get; set; }
        //========================================================================
        /// <summary>
        /// 
        /// </summary>
        public string ProductTypeName  { get; set; }
        //========================================================================
    }
}
