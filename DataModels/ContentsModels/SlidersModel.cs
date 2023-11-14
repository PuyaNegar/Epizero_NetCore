using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ContentsModels
{
    public class SlidersModel : ModifyDateTimeWithUserModel
    {

        public string Title { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Alt { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string PicPath { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public string Link { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public int Inx { get; set; }
        //======================================================
    }
}
