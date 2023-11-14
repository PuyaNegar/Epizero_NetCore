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
using Common.Enums;
using PanelViewModels.TeacherTrainingsViewModels;
using PanelBusinessLogicLayer.UtilityComponents.SmsComponents;

namespace PanelBusinessLogicLayer.BusinessComponents.TeacherTrainingsComponents
{
    public class TeacherOnlineClassesComponent : IDisposable
    {
        private Repository<OnlineClassesModel> onlineClassesRepository;
        private BigBlueButtonAPIClient client;
        int onlineClassDuration = 200;
        public TeacherOnlineClassesComponent()
        {
            onlineClassesRepository = new Repository<OnlineClassesModel>();
            client = new BigBlueButtonAPIClient(new BigBlueButtonAPISettings() { ServerAPIUrl = AppConfigProvider.GetBigBlueButtonServerUrl(), SharedSecret = AppConfigProvider.GetBigBlueButtonSecretKey() }, new HttpClient());
        }
        //==============================================
        public List<TeacherOnlineClassesViewModel> ReadActiveClass(int teacherUserId)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var result = onlineClassesRepository.Where(c => c.CourseMeeting.Course.CourseCategoryTypeId == (int)CourseCategoryType.Training && c.CourseMeeting.TeacherUserId == teacherUserId && c.EndTime > DateTime.UtcNow && c.IsIgnoreClass == false && c.CourseMeeting.IsActive && c.CourseMeeting.Course.IsActive, c => c.CourseMeeting.Course, c => c.CourseMeeting.TeacherUser).Select(c => new TeacherOnlineClassesViewModel()
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
        public List<TeacherOnlineClassesViewModel> Read(int teacherUserId)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            using (var courseMeetingsRepository = new Repository<CourseMeetingsModel>())
            {
                var startDateTime = DateTime.UtcNow.GetDayStartUTC();
                var endDateTime = DateTime.UtcNow.GetDayEndUTC();
                var result = courseMeetingsRepository.Where(c => c.Course.CourseCategoryTypeId == (int)CourseCategoryType.Training && c.TeacherUserId == teacherUserId && startDateTime <= c.StartDateTime && c.StartDateTime <= endDateTime && c.IsActive && c.Course.IsActive, c => c.Course, c => c.TeacherUser)
                    .OrderByDescending(c => c.StartDateTime).Select(c => new TeacherOnlineClassesViewModel()
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
        public void Delete(int teacherUserId, int courseMeetingId)
        {
            var onlineClasses = onlineClassesRepository.Where(c => c.CourseMeetingId == courseMeetingId && c.CourseMeeting.TeacherUserId == teacherUserId && c.EndTime > DateTime.UtcNow && c.IsIgnoreClass == false).ToList();
            foreach (var onlineClass in onlineClasses)
            {
                onlineClass.IsIgnoreClass = true;
                onlineClassesRepository.Update(onlineClass);
                try { client.EndMeetingAsync(new EndMeetingRequest { meetingID = onlineClass.MeetingId, password = "Teacher_@123456789@" }); } catch { }
            }
            onlineClassesRepository.SaveChanges();
        }
        //========================================================
        public string JoinToClass(int teacherUserId, int courseMeetingId)
        {
            var courseMeeting = GetCourseMeeting(courseMeetingId, teacherUserId);
            var result = onlineClassesRepository.FirstOrDefault(c => c.CourseMeetingId == courseMeetingId && c.CourseMeeting.IsActive && c.CourseMeeting.Course.IsActive && c.CourseMeeting.TeacherUserId == teacherUserId && c.EndTime > DateTime.UtcNow && c.IsIgnoreClass == false);

            if (result != null && !IsMeetingRunning(result))
            {
                result.IsIgnoreClass = true;
                onlineClassesRepository.Update(result);
                onlineClassesRepository.SaveChanges();
                result = null;
            }

            if (result == null)
                return CreateMeeting(courseMeeting, teacherUserId);
            else
                return Join(courseMeeting, result.MeetingId, teacherUserId);
        }
        //========================================================
        string CreateMeeting(CourseMeetingsModel courseMeetings, int teacherId)
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

            //var recordingUrl = client.GetRecordingsAsync(new GetRecordingsRequest { meetingID = guid }).Result;
            //recordingUrl.recordings.FirstOrDefault().playbacks.
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

            return Join(courseMeetings, guid, teacherId);

        }
        //========================================================
        string Join(CourseMeetingsModel courseMeeting, string meetingId, int teacherId)
        {
            var requestJoin = new JoinMeetingRequest { meetingID = meetingId };
            requestJoin.password = "Teacher_@123456789@";
            requestJoin.userID = teacherId.ToString();
            requestJoin.fullName = "استاد " + courseMeeting.TeacherUser.FirstName + " " + courseMeeting.TeacherUser.LastName;
            requestJoin.avatarURL = courseMeeting.TeacherUser.PersonalPicPath;   //"https://panel.atashpazmath.com/assets/img/3.png";

            var url = client.GetJoinMeetingUrl(requestJoin);
            StartOnlineClassesSmsComponent.Operation(courseMeeting.Id, teacherId);
            return url;
        }
        //========================================================
        CourseMeetingsModel GetCourseMeeting(int courseMeetingId, int teacherUserId)
        {
            using (var courseMeetingsRepository = new Repository<CourseMeetingsModel>())
            {
                var cdnUrl = AppConfigProvider.CdnUrl();
                var result = courseMeetingsRepository.Where(c => c.Id == courseMeetingId && c.IsActive && c.Course.IsActive && c.TeacherUserId == teacherUserId, c => c.TeacherUser, c => c.Course).Select(c => new CourseMeetingsModel()
                {
                    Id = c.Id,
                    Name = c.Name + " ( " + c.Course.Name + " ) ",
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
