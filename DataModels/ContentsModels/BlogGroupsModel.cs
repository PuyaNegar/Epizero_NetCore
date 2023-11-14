using System.Collections.Generic;
using DataModels.Base;

namespace DataModels.ContentsModels
{
    public class BlogGroupsModel : ModifyDateTimeWithUserModel
    {
        public BlogGroupsModel()
        {
            blogs = new HashSet<BlogsModel>();
        }
        //====================================================
        ///<summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        //====================================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<BlogsModel> blogs { get; set; }
    }
}
