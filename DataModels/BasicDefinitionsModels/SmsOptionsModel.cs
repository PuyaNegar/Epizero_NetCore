using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.BasicDefinitionsModels
{
   public class SmsOptionsModel
    {
        public SmsOptionsModel()
        {
            StudentUserSmsOptions = new HashSet<StudentUserSmsOptionsModel>();
        }
        public int Id { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        public int Price { get; set; }
        //===================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
   
        //===================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StudentUserSmsOptionsModel> StudentUserSmsOptions { get; set; }
    }
}
