 
namespace WebViewModels.OrdersViewModel
{
    public class AddOrderRequestViewModel
    {
        //======================================================================
        /// <summary>
        /// شناسه  کارت
        /// </summary>
        public int OrderId { get; set; }
        //======================================================================
        /// <summary>
        /// شناسه  کارت رمز شده
        /// </summary>
        //[Required(ErrorMessage = "شناسه سبد خرید نباید خالی باشد")]
        public string HashOrderId { get; set; }
        //======================================================================
        /// <summary>
        /// 
        /// </summary>
        public int AcademyProductId { get; set; }
        //======================================================================
        /// <summary>
        /// 
        /// </summary>
        public int AcademyProductTypeId {   get;set;}
        //======================================================================
    }
}
