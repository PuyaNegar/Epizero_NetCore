using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ContentsModels
{
    public class CommentTypesModel : IdentifierModel
    {
        public CommentTypesModel()
        {
            OldStudentComments = new HashSet<OldStudentCommentsModel>();
        }
        //*******************************************************************
        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
        //*******************************************************************
        /// <summary>
        /// عنوان لاتین
        /// </summary>
        public string NameEN { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<OldStudentCommentsModel> OldStudentComments { get; set; }
    }
}
