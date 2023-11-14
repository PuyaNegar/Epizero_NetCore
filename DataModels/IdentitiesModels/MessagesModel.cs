using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.IdentitiesModels
{
    public class MessagesModel : ModifyDateTimeWithUserModel
    {
        public MessagesModel()
        {
            this.MessageReceiverUsers = new HashSet<MessageReceiverUsersModel>();
            this.MessageTags = new HashSet<MessageTagsModel>();
        }
        //================================================
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        //================================================
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
        //================================================
        /// <summary>
        /// 
        /// </summary>
        public string TagsExpression { get; set; }
        //================================================================
        /// <summary>
        /// 
        /// </summary>
        public int MessageTypeId { get; set; }
        //================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual MessageTypesModel MessageType { get; set; }
        //================================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<MessageReceiverUsersModel> MessageReceiverUsers { get; set; }
        //================================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<MessageTagsModel> MessageTags { get; set; }

    }
}
