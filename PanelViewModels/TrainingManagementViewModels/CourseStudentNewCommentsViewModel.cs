using Common.Enums;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace PanelViewModels.TrainingManagementViewModels
{
    public class CourseStudentNewCommentsViewModel
    {
        public int Id { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نظر")]
        public string Comment { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "امتیاز")]
        public decimal? Rate { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public ActiveStatus IsActive { get; set; }
        public string IsActiveName { get; set; }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ ثبت")]
        public string RegDateTime { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام دوره")]
        public string CourseName { get; set; }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "دانش آموز")]
        public string StudentUserFullName { get; set; }

    }
}
