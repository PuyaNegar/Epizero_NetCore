using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.ContentsViewModels
{
   public class TeachersCourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BannerPicPath { get; set; }
        public string TeacherPersonalPicPath { get; set; }
        public string TeacherFullName { get; set; }
        public string TeacherSkill { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public float DiscountPercent { get; set; }
    }
}
