using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.ContentsViewModels
{
    public class CommentsViewModel
    {
        public int Id { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        public string Comment { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        public DateTime RegDateTimeComment { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        public int Inx { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        public int StudentUserId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        /// <summary>
        /// 
        /// </summary>
        public int CommentTypeId { get; set; }
    }
}
