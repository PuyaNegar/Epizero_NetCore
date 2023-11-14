using DataModels.ContentsModels;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.TrainingManagementModels
{
    public class CommentOldStudentCoursesModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public int Inx { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime ModDateTime { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public int CourseId { get; set; }
        public virtual CoursesModel Course { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public int OldStudentCommentId { get; set; }
        public virtual OldStudentCommentsModel OldStudentComment { get; set; }
        //===================================================== ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int ModUserId { get; set; }

        //============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel ModUser { get; set; }
    }
}
