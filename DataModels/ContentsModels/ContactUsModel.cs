using DataModels.Base;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ContentsModels
{
    public class ContactUsModel : ModifyDateTimeModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string FullName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string MobNo { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsRead { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int? CourseId { get; set; }

        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual CoursesModel Course { get; set; }
    }
}
