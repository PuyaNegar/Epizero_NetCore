using DataModels.BasicDefinitionsModels;
using System;

namespace DataModels.IdentitiesModels
{
    public class MessageTagsModel
    {
        //===============================================
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

        //============================================================ ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int MessageId { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual MessagesModel Message { get; set; }

        //============================================
        /// <summary>
        /// 
        /// </summary>
        public int TagId { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual TagsModel Tag { get; set; }

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
