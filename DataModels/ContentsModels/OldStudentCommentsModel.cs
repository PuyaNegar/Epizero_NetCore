using DataModels.Base;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace DataModels.ContentsModels
{
    public class OldStudentCommentsModel : ModifyDateTimeWithUserModel
    {
        public OldStudentCommentsModel()
        {
            CommentOldStudentCourses = new HashSet<CommentOldStudentCoursesModel>();
        }
        public string Title { get; set; }
        public string CommentText { get; set; }
        public string CommentAudio{ get; set; }
        public string CommentVideo { get; set; }
        public DateTime  RegDateTimeComment { get; set; }
        public bool IsActive { get; set; }
        public int Inx { get; set; }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public int StudentUserId { get; set; }
        public virtual UsersModel StudentUser { get; set; }

        public int CommentTypeId { get; set; }
        public virtual CommentTypesModel CommentType { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CommentOldStudentCoursesModel> CommentOldStudentCourses { get; set; }
    }
}
