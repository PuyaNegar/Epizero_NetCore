using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.IdentitiesViewModels
{
    public class UserProfilesViewModel
    {
        //*******************************************************************
        /// <summary>
        /// شناسه پروفایل کاربر
        /// </summary>
        public int Id { get; set; } 
        //*******************************************************************
        /// <summary>
        /// جنسيت
        /// </summary>
        [Display(Name = "جنسيت")]
        public ActiveStatus Gender { get; set; } 
        //*******************************************************************
        /// <summary>
        /// جنسيت
        /// </summary>
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        //*******************************************************************
        /// <summary>
        /// نام‌خانوادگی 
        /// </summary>
        [Display(Name = "نام‌خانوادگی")]
        public string LastName { get; set; } 
        //*******************************************************************
        /// <summary>
        /// شناسه کاربر
        /// </summary>
        public int UserId { get; set; }
        //*******************************************************************
        [Display(Name = "نام پدر")]
        public string FatherName { get; set;  }

        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "وضعیت تاهل")]
        public ActiveStatus IsMarried { get; set;  }




    }
}
