 
namespace WebViewModels.OrdersViewModel
{
    public class RemoveOrderRequestViewModel
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
        public int OrderDetailId { get; set; }
        //======================================================================
      
    }
}
