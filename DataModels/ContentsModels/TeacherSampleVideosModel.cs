using DataModels.Base;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ContentsModels
{
    public class TeacherSampleVideosModel : ModifyDateTimeWithUserModel
    {
        //*******************************************************************
        /// <summary>
        /// اولویت
        /// </summary>
        public int Inx { get; set; }
        //*******************************************************************
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }
        //*******************************************************************
        /// <summary>
        /// فعال بودن
        /// </summary>
        public bool IsActive { get; set; }
        //*******************************************************************
        /// <summary>
        /// لینک
        /// </summary>
        public string Link { get; set; }
        //====================================================================
        /// <summary>
        /// 
        /// </summary>
        public int TeacherId { get; set; }
        //====================================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual  UsersModel Teacher{ get; set; }
    }
}
