using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using Common.Extentions;
using WebViewModels.ContentsViewModels;
using Common.Functions;
using Common.Objects;

namespace WebBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class CourseNotificationsComponent : IDisposable
    {
        private Repository<CourseNotificationsModel> courseNotificationsRepository;
        private Repository<NotificationsModel> notificationsRepository;
        //========================================
        public CourseNotificationsComponent()
        {
            courseNotificationsRepository = new Repository<CourseNotificationsModel>();
            notificationsRepository = new Repository<NotificationsModel>();
        }
        //========================================
        public List<CourseNotificationsViewModel> Read(int studentUserId)
        {
            var courseIds = StudentCourseMeetingsComponent.Read(studentUserId).Select(c => c.CourseId).Distinct();
            var notificationIds = courseNotificationsRepository.Where(c => courseIds.Contains(c.CourseId)).Select(c=> c.NotificationId).ToList().Distinct();

            var result = notificationsRepository.Where(c => notificationIds.Contains(c.Id) && c.IsActive && c.FromDate <= DateTime.UtcNow && DateTime.UtcNow <= c.ToDate)
                .Select(c => new CourseNotificationsViewModel()
                {
                    Id = c.Id,
                    Description = c.Description,
                    Title = c.Title,
                }).ToList();
            return result;
        }
        //========================================
        public void Dispose()
        {
            courseNotificationsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
