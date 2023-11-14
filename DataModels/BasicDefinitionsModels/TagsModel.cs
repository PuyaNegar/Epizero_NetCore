using DataModels.Base;
using DataModels.IdentitiesModels;
using System.Collections.Generic;

namespace DataModels.BasicDefinitionsModels
{
    public class TagsModel : ModifyDateTimeWithUserModel
    {
        public TagsModel()
        {
            this.MessageTags = new HashSet<MessageTagsModel>();
        }

        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }

        //=====================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<MessageTagsModel> MessageTags { get; set; }
    }

}
