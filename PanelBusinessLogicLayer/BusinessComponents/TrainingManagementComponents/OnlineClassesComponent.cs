using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using Common.Extentions;
using System.Linq;
using Common.Functions;
using Common.Objects;
using BigBlueButtonAPI.Core;
using DataModels.IdentitiesModels;
using System.Net.Http;
using PanelViewModels.TrainingManagementViewModels;
using Common.Enums;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
    public class OnlineClassesComponent : IDisposable
    {
        private Repository<OnlineClassesModel> onlineClassesRepository;
        private BigBlueButtonAPIClient client;
        int onlineClassDuration = 200;
        public OnlineClassesComponent()
        {
            onlineClassesRepository = new Repository<OnlineClassesModel>();
            client = new BigBlueButtonAPIClient(new BigBlueButtonAPISettings() { ServerAPIUrl = AppConfigProvider.GetBigBlueButtonServerUrl(), SharedSecret = AppConfigProvider.GetBigBlueButtonSecretKey() }, new HttpClient());
        }
        //==============================================
        public List<OnlineClassesViewModel> ReadActiveClass()
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var result = onlineClassesRepository.Where(c => c.CourseMeeting.Course.CourseCategoryTypeId == (int)CourseCategoryType.Training && c.EndTime > DateTime.UtcNow && c.IsIgnoreClass == false && c.CourseMeeting.IsActive && c.CourseMeeting.Course.IsActive, c => c.CourseMeeting.Course, c => c.CourseMeeting.TeacherUser).Select(c => new OnlineClassesViewModel()
            {
                CourseMeetingId = c.CourseMeetingId,
                CourseMeetingName = c.CourseMeeting.Name,
                CourseName = c.CourseMeeting.Course.Name,
                StartDateTime = c.CourseMeeting.StartDateTime.ToLocalDateTimeShortFormatString(),
                TeacherFullName = c.CourseMeeting.TeacherUser.FirstName + " " + c.CourseMeeting.TeacherUser.LastName,
                TeacherPersonalPicPath = string.IsNullOrEmpty(c.CourseMeeting.TeacherUser.PersonalPicPath) ? string.Empty : cdnUrl + c.CourseMeeting.TeacherUser.PersonalPicPath,
            }).ToList();
            return result;
        }
        //==============================================
        public List<OnlineClassesViewModel> Read()
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            using (var courseMeetingsRepository = new Repository<CourseMeetingsModel>())
            {
                var startDateTime = DateTime.UtcNow.GetDayStartUTC();
                var endDateTime = DateTime.UtcNow.GetDayEndUTC();
                var result = courseMeetingsRepository.Where(c =>c.Course.CourseCategoryTypeId == (int)CourseCategoryType.Training &&  startDateTime <= c.StartDateTime && c.StartDateTime <= endDateTime && c.IsActive && c.Course.IsActive, c => c.Course, c => c.TeacherUser)
                    .OrderByDescending(c => c.StartDateTime).Select(c => new OnlineClassesViewModel()
                    {
                        CourseMeetingId = c.Id,
                        CourseMeetingName = c.Name,
                        CourseName = c.Course.Name,
                        StartDateTime = c.StartDateTime.ToLocalDateTimeShortFormatString(),
                        TeacherFullName = c.TeacherUser.FirstName + " " + c.TeacherUser.LastName,
                        TeacherPersonalPicPath = string.IsNullOrEmpty(c.TeacherUser.PersonalPicPath) ? string.Empty : cdnUrl + c.TeacherUser.PersonalPicPath,
                    }).ToList();
                return result;
            }
        }
        //==============================================
        public void Delete(int courseMeetingId)
        {
            var onlineClasses = onlineClassesRepository.Where(c => c.CourseMeetingId == courseMeetingId && c.EndTime > DateTime.UtcNow && c.IsIgnoreClass == false).ToList();
            foreach (var onlineClass in onlineClasses)
            {
                onlineClass.IsIgnoreClass = true;
                onlineClassesRepository.Update(onlineClass);
                try { client.EndMeetingAsync(new EndMeetingRequest { meetingID = onlineClass.MeetingId, password = "Teacher_@123456789@" }); } catch { }
            }
            onlineClassesRepository.SaveChanges();
        }
        //========================================================
        public string JoinToClass(int courseMeetingId, int currentUserId)
        {
            var courseMeeting = GetCourseMeeting(courseMeetingId);
            var result = onlineClassesRepository.FirstOrDefault(c => c.CourseMeetingId == courseMeetingId && c.CourseMeeting.IsActive && c.CourseMeeting.Course.IsActive && c.EndTime > DateTime.UtcNow && c.IsIgnoreClass == false);

            if (result != null && !IsMeetingRunning(result))
            {
                result.IsIgnoreClass = true;
                onlineClassesRepository.Update(result);
                onlineClassesRepository.SaveChanges();
                result = null;
            }

            if (result == null)
                return CreateMeeting(courseMeeting, currentUserId);
            else
                return Join(result.MeetingId, currentUserId);
        }
        //========================================================
        string CreateMeeting(CourseMeetingsModel courseMeetings, int currentUserId)
        {
            var guid = Guid.NewGuid().ToString();
            var result = client.CreateMeetingAsync(new CreateMeetingRequest
            {
                lockSettingsDisableCam = true,
                lockSettingsDisableMic = true,
                lockSettingsDisablePrivateChat = true,
                name = courseMeetings.Name,
                meetingID = guid,
                record = true,
                duration = onlineClassDuration,
                maxParticipants = 2000,
                attendeePW = "Student_@123456789@",
                moderatorPW = "Teacher_@123456789@",
                welcome = "به سیستم آموزش آنلاین اپیزرو خوش آمدید",
                logoutURL = AppConfigProvider.GetOnlineClassLogoutUrl(),
                copyright = "سهاد",
                // autoStartRecording = true , 
                allowStartStopRecording = true,
                bannerText = "سیستم آموزش آنلاین اپیزرو",
                logo = "https://panel.epizero.ir/assets/img/3.png",
            }).Result;
            if (result.returncode == Returncode.FAILED)
                throw new CustomException("خطا در ایجاد جلسه");
            var model = new OnlineClassesModel()
            {
                IsIgnoreClass = false,
                RecordUrl = AppConfigProvider.GetBigBlueButtonRecordUrl() + result.internalMeetingID,
                MeetingId = guid.ToString(),
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddMinutes(onlineClassDuration),
                CourseMeetingId = courseMeetings.Id,
            };
            onlineClassesRepository.Add(model);
            onlineClassesRepository.SaveChanges();

            return Join(guid, currentUserId);

        }
        //========================================================
        string Join(string meetingId, int currentUserId)
        {
            var requestJoin = new JoinMeetingRequest { meetingID = meetingId };
            requestJoin.password = "Teacher_@123456789@";
            requestJoin.userID = currentUserId.ToString();
            var adminUser = GetAdminUser(currentUserId);
            requestJoin.fullName = "پشتیبان " + adminUser.FirstName + " " + adminUser.LastName;
            requestJoin.avatarURL = "https://panel.atashpazmath.ir/assets/img/3.png";
            var url = client.GetJoinMeetingUrl(requestJoin);
            return url;
        }
        //========================================================
        CourseMeetingsModel GetCourseMeeting(int courseMeetingId)
        {
            using (var courseMeetingsRepository = new Repository<CourseMeetingsModel>())
            {
                var cdnUrl = AppConfigProvider.CdnUrl();
                var result = courseMeetingsRepository.Where(c => c.Id == courseMeetingId && c.IsActive && c.Course.IsActive, c => c.TeacherUser, c => c.Course).Select(c => new CourseMeetingsModel()
                {
                    Id = c.Id,
                    Name = c.Name + " ( " + c.Course.Name + " ) ",
                    TeacherUserId = c.TeacherUserId,
                    TeacherUser = new UsersModel() { FirstName = c.TeacherUser.FirstName, LastName = c.TeacherUser.LastName, PersonalPicPath = string.IsNullOrEmpty(c.TeacherUser.PersonalPicPath) ? string.Empty : cdnUrl + c.TeacherUser.PersonalPicPath, }
                }).SingleOrDefault();
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result;
            }
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
        //===========================================================
        UsersModel GetAdminUser(int currentUserId)
        {
            using (var usersRepository = new Repository<UsersModel>())
            {
                var result = usersRepository.SingleOrDefault(c => c.Id == currentUserId);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result;
            }
        }
        //============================================== Disposing
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
