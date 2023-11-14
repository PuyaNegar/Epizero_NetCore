using DataModels.Base;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.TrainingManagementModels
{
    public class CourseStudentNewCommentsModel 
    {
        public int Id { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public string Comment { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public decimal? Rate { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public DateTime RegDateTime { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public int CourseId { get; set; }
        public virtual CoursesModel Course { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        public virtual UsersModel StudentUser { get; set; }


        //=============================================================
        /// <summary>
        /// تاریخ تغییر
        /// </summary>
        public DateTime? ModDateTime { get; set; }
 
        //=============================================================
        /// <summary>
        /// شناسه ویرایش کننده
        /// </summary>
        public int? ModUserId { get; set; }
        //=============================================================
        /// <summary>
        /// ویرایش کننده
        /// </summary>
        public virtual UsersModel ModUser { get; set; }

    }
}
