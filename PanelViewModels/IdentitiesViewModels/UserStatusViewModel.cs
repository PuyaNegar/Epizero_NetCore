using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.Identity
{
    public class UserStatusViewModel
    {
        //========================================================================
        /// <summary>
        /// شناسه کاربر
        /// </summary>
        [Display(Name = "شناسه کاربر")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int UserId { get; set; }

        //========================================================================
        /// <summary>
        /// نام کاربری
        /// </summary>
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        //========================================================================
        /// <summary>
        /// وضعیت کاربر
        /// </summary>
        [Display(Name = "وضعيت کاربر")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }
    }
}
