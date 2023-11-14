using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
   public class CourseAndCoursemeetingRegistrationsViewModel
    {
        public int Id { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام دوره")]
        public string CourseName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام جلسه دوره")]
        public string CourseMeetingName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = " دوره / جلسه ")]
        public string CourseMeetingStudentName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام دانش آموز")]
        public string StudentFullName { get; set; }
        //=========================================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        [Display(Name = "وضعیت")]
        public string IsActiveName { get; set; }
        //=========================================================
        /// <summary>
        /// فعال یا غیرفعال
        /// </summary>
        [Display(Name = "نوع ثبت نامی ")]
        public string IsOnlineRegistrationName { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ ثبت نام")]
        public string RegDateTime { get; set; }
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "نام شهر")]
        public string CityName { get; set; }
    }
}
