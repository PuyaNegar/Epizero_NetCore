using Common.Extentions;
using Common.Functions;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
   public class LiveOnlineClassesComponent : IDisposable
    {
        private Repository<OnlineClassesModel> onlineClassesRepository;
        //===============================================================================
        public LiveOnlineClassesComponent()
        {
            onlineClassesRepository = new Repository<OnlineClassesModel>();
        }
        //===============================================================================
        public List<OnlineClassesViewModel> Read(int studentUserId )
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var model = StudentCourseMeetingsComponent.Read(studentUserId).Where(c => DateTime.UtcNow.GetDayStartUTC() <= c.StartDateTime && c.StartDateTime <= DateTime.UtcNow.GetDayEndUTC()).ToList();
            var courseMeetingIds = onlineClassesRepository.Where(c => model.Select(d=>d.Id).Contains(c.CourseMeetingId)   && c.CourseMeeting.IsActive && c.CourseMeeting.Course.IsActive && c.EndTime > DateTime.UtcNow && c.IsIgnoreClass == false).Select(c=>c.CourseMeetingId).ToList();
            var result = model.Where(c=> courseMeetingIds.Contains(c.Id)).Select(c => new OnlineClassesViewModel()
            {
                CourseMeetingId = c.Id,
                CourseName = c.Course.Name,
                CourseMeetingName = c.Name,
                StartDateTime = c.StartDateTime.ToLocalDateTimeShortFormatString(),
                TeacherFullName = c.TeacherUser.FirstName + " " + c.TeacherUser.LastName,
                TeacherPersonalPicPath = string.IsNullOrEmpty(c.TeacherUser.PersonalPicPath) ? string.Empty : cdnUrl + c.TeacherUser.PersonalPicPath,
            }).ToList();
            return result;
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineClassesRepository?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
