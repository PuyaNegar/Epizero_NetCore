using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using TeacherBusinessLogicLayer.UtilityComponents;
using TeacherViewModels.TraningsViewModels;

namespace TeacherBusinessLogicLayer.BusinessComponents.TraningsComponents
{
    public class TeacherCourseVideosComponent : IDisposable
    {
        private Repository<CourseMeetingVideosModel> courseMeetingVideosRepository;
        //=============================================
        public TeacherCourseVideosComponent()
        {
            courseMeetingVideosRepository = new Repository<CourseMeetingVideosModel>();
        }
        //==============================================
        public List<TeacherCourseMeetingVideoGroupsViewModel> Read(int courseId, int teacherUserId)
        {
            using (var courseRepository = new Repository<CoursesModel>())
            {
                var resut = courseRepository.SingleOrDefault(c => c.IsActive && c.Id == courseId && c.TeacherUserId == teacherUserId);
                if (resut == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
            }
            var result = courseMeetingVideosRepository.Where(c => c.CourseMeeting.CourseId == courseId && c.IsActive, c => c.CourseMeeting).ToList()
            .GroupBy(c => new { c.CourseMeetingId, c.CourseMeeting.Name }).Select(c => new TeacherCourseMeetingVideoGroupsViewModel()
            {
                CourseMeentingName = c.Key.Name,
                CourseMeetingVideos = c.Select(d => new TeacherCourseMeetingVideosViewModel()
                {
                    Id = d.Id,
                    IsActive = d.IsActive.ToActiveStatus(),
                    Link = d.Link,
                    IsActiveName = d.IsActive ? "فعال" : "غیر فعال",
                    CourseMeetingId = d.CourseMeetingId,
                    Title = d.Title,
                    CourseMeetingName = d.CourseMeeting.Name,
                }).ToList()
            }).ToList();
            return result;
        }
        //============================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseMeetingVideosRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
