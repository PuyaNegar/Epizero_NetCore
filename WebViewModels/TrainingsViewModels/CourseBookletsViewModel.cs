using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.TrainingsViewModels
{
   public class CourseBookletsViewModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EmbedLink { get; set; }
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }
        //============================================
        /// <summary>
        ///    فایل
        /// </summary>
        public string FilePath { get; set; }
        //============================================

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseName { get; set; }
    }
}
