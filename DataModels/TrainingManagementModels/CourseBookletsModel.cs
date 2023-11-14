using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.TrainingManagementModels
{
    public class CourseBookletsModel : ModifyDateTimeWithUserModel
    {
        public string EmbedLink { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public string FilePath { get; set; }
        //=====================================================
        /// <summary>
        ///  
        /// </summary>
        public bool IsActive { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public int CourseId { get; set; }
        //======================================================
        public virtual CoursesModel Courses { get; set; }
    }
}
