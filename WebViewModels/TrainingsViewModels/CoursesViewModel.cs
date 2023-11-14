using Common.Enums;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using WebViewModels.ContentsViewModels;

namespace WebViewModels.TrainingsViewModels
{
    public class CoursesViewModel
    {
        /// <summary>
        /// مخاطبین
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// تعداد جلسه
        /// </summary>
        public string CourseMeetingCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float DiscountPercent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int NumberQuestions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary> 
        public bool IsMultiTeacher { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string BannerPicPath { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string LogoPicPath { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseTypeId { get; set; }
        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseTypeName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string TeacherPicPath { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int Price { get; set; }
        //===================================================== 
        /// <summary>
        /// درصد تخفیف
        /// </summary>
        public int DiscountPrice { get; set; }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        public int CourseDuration { get; set; }
        //===================================================== 
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public string StartDate { get; set; }
        //=====================================================
        /// <summary>
        /// تاریخ پايان
        /// </summary>
        public string EndDate { get; set; }

        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int TeacherUserId { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string TeacherFullName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string LessonName { get; set; }
        public string LevelName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int  StudentFieldId  { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string MetaDescription { get; set;  }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsShowDetailsInWeb { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsVisibleOnSite { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string LanguageName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary
        public int NumberCoins { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public CourseCategoryType CourseCategoryType { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public StudentAccessToCourseViewModel StudentAccessToCourse { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<CourseMeetingsViewModel> CourseMeetings { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<CourseDescriptionVideosViewModel> CourseDescriptionVideos { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<CourseSampleVideosViewModel> CourseSampleVideos { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public ICollection<SimilarCouresViewModel> SimilarCoures { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<CourseDedicatedTeachersViewModel> CourseDedicatedTeachers { get; set;  }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<CourseFAQsViewModel> CourseFAQs { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<CommentOldStudentCoursesViewModel> CommentOldStudentCourses { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<TeacherResumesViewModel> TeacherResumes { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<ReadCourseStudentNewCommentsViewModel> CourseStudentNewComments { get; set; }

    }
}
