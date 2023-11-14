using Common.Functions;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebViewModels.ContentsViewModels;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
    public class CourseFilterComponent : IDisposable
    {
        private Repository<CoursesModel> coursesRepository;
        //=======================================================
        public CourseFilterComponent()
        {
            coursesRepository = new Repository<CoursesModel>();
        }
        //=======================================================
        public List<FilterdCourseGroupsViewModel> Read(int levelGroupId)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var result = coursesRepository.Where(c => c.Lessons.Level.LevelGroupId == levelGroupId && c.IsActive && c.IsVisibleOnSite, c => c.Lessons.Level.LevelGroup).Select(c => new CoursesModel()
            {
                Id = c.Id,
                Name = c.Name,
                BannerPicPath = string.IsNullOrEmpty(c.BannerPicPath) ? string.Empty : cdnUrl + c.BannerPicPath,
                //DiscountPrice = c.DiscountPrice,
                DiscountPercent = c.DiscountPercent,
                Price = c.Price,
                
                TeacherUser = new DataModels.IdentitiesModels.UsersModel()
                {
                    PersonalPicPath = string.IsNullOrEmpty(c.TeacherUser.PersonalPicPath) ? string.Empty : cdnUrl + c.TeacherUser.PersonalPicPath,
                    FirstName = c.TeacherUser.FirstName,
                    LastName = c.TeacherUser.LastName
                },
                Lessons = new LessonsModel()
                {
                    Level = new LevelsModel() { Id = c.Lessons.Level.Id, Name = c.Lessons.Level.Name }
                }
            }).ToList().GroupBy(c => new { c.Lessons.Level.Id, c.Lessons.Level.Name }).Select(c => new FilterdCourseGroupsViewModel()
            {
                LevelId = c.Key.Id,
                LevelName = c.Key.Name,
                FilterdCourses = c.Select(d => new FilterdCoursesViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    BannerPicPath = d.BannerPicPath,
                    DiscountPrice = Convert.ToInt32( d.Price - (d.Price * d.DiscountPercent / 100)),
                    DiscountPercent = d.DiscountPercent,
                    Price = d.Price,
                    TeacherFullName = d.TeacherUser.FirstName + " " + d.TeacherUser.LastName,
                   TeacherPersonalPicPath = d.TeacherUser.PersonalPicPath , 
                }).ToList(),
            }).ToList();
            return result;
        }
        //=======================================================
        public List<FilterdCourseGroupsViewModel> ReadByCourseTypeId(int courseTypeId)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var result = coursesRepository.Where(c => c.CourseTypeId == courseTypeId && c.IsActive && c.IsVisibleOnSite, c => c.Lessons.Level.LevelGroup).Select(c => new CoursesModel()
            {
                Id = c.Id,
                Name = c.Name,
                BannerPicPath = string.IsNullOrEmpty(c.BannerPicPath) ? string.Empty : cdnUrl + c.BannerPicPath,
                DiscountPercent = c.DiscountPercent,
                Price = c.Price,
                TeacherUser = new DataModels.IdentitiesModels.UsersModel()
                {
                    PersonalPicPath = string.IsNullOrEmpty(c.TeacherUser.PersonalPicPath) ? string.Empty : cdnUrl + c.TeacherUser.PersonalPicPath,
                    FirstName = c.TeacherUser.FirstName,
                    LastName = c.TeacherUser.LastName
                },
                Lessons = new LessonsModel()
                {
                    Level = new LevelsModel() { Id = c.Lessons.Level.Id, Name = c.Lessons.Level.Name }
                }
            }).ToList().GroupBy(c => new { c.Lessons.Level.Id, c.Lessons.Level.Name }).Select(c => new FilterdCourseGroupsViewModel()
            {
                LevelId = c.Key.Id,
                LevelName = c.Key.Name,
                FilterdCourses = c.Select(d => new FilterdCoursesViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    BannerPicPath = d.BannerPicPath,
                    DiscountPrice = Convert.ToInt32( d.Price - (d.Price * d.DiscountPercent / 100)),
                    DiscountPercent = d.DiscountPercent,
                    Price = d.Price,
                    TeacherFullName = d.TeacherUser.FirstName + " " + d.TeacherUser.LastName,
                    TeacherPersonalPicPath = d.TeacherUser.PersonalPicPath,
                }).ToList(),
            }).ToList();
            return result;
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            coursesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
