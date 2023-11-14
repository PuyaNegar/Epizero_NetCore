using System.ComponentModel.DataAnnotations;
 

namespace WebViewModels.IdentitiesViewModels
{
   public class UserLoginLogsViewModel
    {
        public long Id { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "آی پی")]
        public string Ip { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "اطلاعات مرورگر")]
        public string UserAgent { get; set; }
        //======================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "کد ورود")]
        public string Guid { get; set; }
        //====================================== 
    }
}
