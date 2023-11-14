﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.ContentsViewModels
{
    public class CoursePromosViewModel
    {
        public bool IsMultiTeacher { get; set; }
        //========================================================================
        /// <summary>
        /// شناسه
        /// </summary>
        public int Id { get; set; }
        //========================================================================
        /// <summary>
        /// لینک عکس محصول
        /// </summary>
        public string BannerPicPath { get; set; }
        /// <summary>
        /// لینک عکس محصول
        /// </summary>
        public string LogoPicPath { get; set; }
        //========================================================================
        /// <summary>
        /// نام محصول
        /// </summary>
        public string Name { get; set; }
        //========================================================================
        /// <summary>
        /// درصد تخفیف
        /// </summary>
        public int DiscountPrice { get; set; }
        //========================================================================
        /// <summary>
        /// درصد تخفیف
        /// </summary>
        public float DiscountPercent { get; set; }
        //========================================================================
        /// <summary>
        /// مبلغ
        /// </summary>
        public int Price { get; set; }
        //========================================================================
        /// <summary>
        /// 
        /// </summary>
        public int TeacherUserId  { get; set; }
        //========================================================================
        /// <summary>
        /// نام دبیر
        /// </summary>
        public string TeacherFullName { get; set; }
        //========================================================================
        /// <summary>
        /// 
        /// </summary>
        public string TeacherPersonalPicPath { get; set; }
        //========================================================================
        /// <summary>
        /// 
        /// </summary>
      public List<  CourseDedicatedTeachersViewModel> CourseDedicatedTeachers { get; set; }

    }
}
