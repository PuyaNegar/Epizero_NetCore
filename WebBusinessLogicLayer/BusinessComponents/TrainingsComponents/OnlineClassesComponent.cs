using System;
using System.Collections.Generic;
using System.Linq;
using BigBlueButtonAPI.Core;
using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
    public class OnlineClassesComponent : IDisposable
    {
        private Repository<OnlineClassesModel> onlineClassesRepository;
        private BigBlueButtonAPIClient client;
        //=====================================================
        public OnlineClassesComponent()
        {
            onlineClassesRepository = new Repository<OnlineClassesModel>();
            client = new BigBlueButtonAPIClient(new BigBlueButtonAPISettings() { ServerAPIUrl = AppConfigProvider.GetBigBlueButtonServerUrl(), SharedSecret = AppConfigProvider.GetBigBlueButtonSecretKey() }, new System.Net.Http.HttpClient());
        }
        //===================================================== 
        public List<OnlineClassesViewModel> Read(int studentUserId)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var model = StudentCourseMeetingsComponent.Read(studentUserId);
            var result = model.Where(c => DateTime.UtcNow.GetDayStartUTC() <= c.StartDateTime && c.StartDateTime <= DateTime.UtcNow.GetDayEndUTC()).Select(c => new OnlineClassesViewModel()
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
        //===================================================== 
        public string JoinToClass(int studentUserId, int courseMeetingId)
        {
            var result = onlineClassesRepository.FirstOrDefault(c => c.CourseMeeting.Course.CourseCategoryTypeId == (int)CourseCategoryType.Training && c.CourseMeetingId == courseMeetingId && c.CourseMeeting.IsActive && c.CourseMeeting.Course.IsActive && c.EndTime > DateTime.UtcNow && c.IsIgnoreClass == false);
            if (result == null)
                throw new CustomException("کلاس فعلا شروع نشده است. تا شروع کلاس لطفا منتظر بمانید ...");
            ValidateCourseStudent(result.CourseMeetingId, studentUserId);
            if (!IsMeetingRunning(result))
                throw new CustomException("زمان کلاس به پایان رسیده است");
            return Join(studentUserId, result.MeetingId);
        }
        //========================================================
        string Join(int studentUserId, string meetingId)
        {
            var requestJoin = new JoinMeetingRequest { meetingID = meetingId };
            requestJoin.password = "Student_@123456789@";
            requestJoin.userID = studentUserId.ToString();
            requestJoin.avatarURL = AppConfigProvider.GetApplicationUrl() + "/assets/img/profile_image_man.png";
            requestJoin.fullName = GetStudentUserFullName(studentUserId);
            var url = client.GetJoinMeetingUrl(requestJoin);
            return url;
        }
        //==============================================
        bool IsMeetingRunning(OnlineClassesModel model)
        {
            var result = client.IsMeetingRunningAsync(new IsMeetingRunningRequest() { meetingID = model.MeetingId }).Result;
            if (result.returncode == Returncode.FAILED)
                return false;
            if (result.running != null && result.running.Value)
                return true;
            else
                return false;
        }
        //===============================================================================
        void ValidateCourseStudent(int courseMeetingId, int studentUserId)
        {
            var result = StudentCourseMeetingsComponent.Read(studentUserId).Where(c => c.Id == courseMeetingId).Any();
            if (!result)
                throw new CustomException(" دانش آموز در لیست این جلسه وجود ندارد ");
        }
        //===============================================================================
        string GetStudentUserFullName(int studentUserId)
        {
            using (var usersRepository = new Repository<UsersModel>())
            {
                var result = usersRepository.Where(c => c.Id == studentUserId && c.UserGroupId == (int)UserGroup.Student).Select(c => new UsersModel()
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                }).SingleOrDefault();
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result.FirstName + " " + result.LastName;
            }
        }
        //==============================================
        public int GetCountOnlineClasses()
        {
            var count =  onlineClassesRepository.SelectAllAsQuerable().Count() * 1.5;
            return Convert.ToInt32(count);
        }

      
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineClassesRepository?.Dispose();
            client = null;
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
