using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.IdentitiesViewModels
{
    public class EditAdminUsersViewModel
    {
        //========================================================================
        /// <summary>
        /// شناسه کاربر
        /// </summary>
        [Display(Name = "شناسه کاربر")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int Id { get; set; }

        //========================================================================
        /// <summary>
        /// نام کاربری
        /// </summary>
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        //========================================================================
        /// <summary>
        /// وضعیت کاربر
        /// </summary>
        [Display(Name = "وضعيت کاربر")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "فیلد بایستی حداکثر 100 کاراکتر باشد")]
        public string FirstName { get; set; }
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        [StringLength(100, ErrorMessage = "فیلد بایستی حداکثر 100 کاراکتر باشد")]
        public string LastName { get; set; }
        //=============================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "گروه کاربری")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int UserGroupId { get; set;  }
        //=============================================================================
    }
}
