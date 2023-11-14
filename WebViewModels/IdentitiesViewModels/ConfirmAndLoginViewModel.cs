using System.ComponentModel.DataAnnotations;

namespace WebViewModels.IdentitiesViewModels
{
    public class ConfirmAndLoginViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string HashId { get; set; }
        //=======================================================================
        /// <summary>
        /// 
        /// </summary>
        [RegularExpression(pattern: @"^\d{11}$", ErrorMessage = "شماره موبایل صحیح وارد نشده است")]
        [Required(ErrorMessage = "شماره موبایل نبایستی خالی باشد")]
        public string UserName { get; set; }
        //======================================================================= 
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "کد تایید نبایستی خالی باشد")]
        [RegularExpression(pattern: @"^\d+$", ErrorMessage = "کد تایید بایستی بصورت عددی باشد")]
        public string ConfirmCode { get; set; }
 
        //======================================================================
        /// <summary>
        /// 
        /// </summary>
        public string UniqueIdentifier { get; set; }
    }
}
