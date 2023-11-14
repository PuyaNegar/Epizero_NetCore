using DataModels.Base;
using System;

namespace DataModels.IdentitiesModels
{
    public class MessageReceiverUsersModel : IdentifierModel
    {
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ReadDateTime { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsRead { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int MessageId { get; set; }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public virtual MessagesModel Message { get; set; }
        //========================================== ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }
        //==========================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel User { get; set; }

    }
}
