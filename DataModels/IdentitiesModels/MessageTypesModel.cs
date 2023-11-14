using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.IdentitiesModels
{
   public class MessageTypesModel : IdentifierModel
    {
        public MessageTypesModel()
        {
            this.Messages = new HashSet<MessagesModel>();
        } 
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string NameEN { get; set; }
        //==========================================================
        public ICollection<MessagesModel> Messages { get; set; }
    }
}
