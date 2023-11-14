using DataModels.Base;

namespace DataModels.ContentsModels
{
    public class BlogsModel : ModifyDateTimeWithUserModel
    {
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string PicPath { get; set; }
        //=================================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int BlogGroupId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual BlogGroupsModel BlogGroups { get; set; }
        //=====================================================
    }
}
