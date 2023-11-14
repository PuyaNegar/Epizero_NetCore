using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewModels.ContentsViewModels
{
   public class TeacherIntroductionsViewModel
    {
        //=====================================================
        /// <summary>
        ///  
        /// </summary>
        public string FullName { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string PersonalPicPath { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string BannerPicPath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string Skill { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public string TeacherPrefix { get; set; }
        public string MetaDescription { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<TeacherSampleVideosViewModel> TeacherSampleVideos { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<TeachersCourseViewModel> TeachersCourse { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<TeacherResumesViewModel> TeacherResumes { get; set;  }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public List< AcceptedStudentInEntranceExamGroupsViewModel> AcceptedStudentInEntranceExamGroups { get; set;  }
        //=====================================================
    }
}
