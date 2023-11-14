using Common.Extentions;
using Common.Objects;
using DataModels.HomeworksModels;
using System;
using System.Linq;  
using Common.Functions;
using PanelBusinessLogicLayer.BusinessComponents.TeacherTrainingsComponents;
using PanelViewModels.TeacherTrainingsViewModels;

namespace PanelBusinessLogicLayer.BusinessServices.TeacherTrainingsServices
{

    public class TeacherHomeworksService : IDisposable
    {
        private TeacherHomeworksComponent homeworksComponent;
        //===============================================================================
        public TeacherHomeworksService()
        {
            homeworksComponent = new TeacherHomeworksComponent();
        }
        //===============================================================================
        public SysResult Read(int CourseMeetingId, int teacherUserId)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var result = homeworksComponent.Read(CourseMeetingId, teacherUserId).Select(c => new TeacherHomeworksViewModel()
            {
                Id = c.Id,
                Description = c.Description,
                FilePath = string.IsNullOrEmpty(c.FilePath) ? null : cdnUrl + c.FilePath,
                ExpiredDate = c.ExpiredDate.ToLocalDateTimeShortFormatString(),
                RegDateTime = c.RegDateTime.ToLocalDateTimeShortFormatString(),
                Title = c.Title,
                IsActiveName = c.IsActive ? "فعال" : "غیرفعال",
                CourseMeetingId = c.CourseMeetingId, 
                CourseMeetingName = c.CourseMeeting.Name,
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult Add(TeacherHomeworksViewModel request, int currentUserId)
        {
            if (string.IsNullOrEmpty(request.FilePath))
                throw new CustomException("فایل تکلیف نمی تواند خالی باشد.");
            var model = new HomeworksModel()
            {
                Description = request.Description,
                Title = request.Title,
                ExpiredDate = request.ExpiredDate.CharacterAnalysis().ToDate().ToUtcDateTime(),
                CourseMeetingId = request.CourseMeetingId,
                FilePath = request.FilePath, 
                IsActive = request.IsActive.ToBoolean(),
                RegDateTime = DateTime.UtcNow,  
                ModUserId = currentUserId 
            };
            homeworksComponent.Add(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }

        //===============================================================================
        public SysResult<TeacherHomeworksViewModel> Find(int id, int currentUserId)
        {
            var result = homeworksComponent.Find(id, currentUserId);
            var model = new TeacherHomeworksViewModel()
            {
                Id = result.Id,
                CourseMeetingName = result.CourseMeeting.Name,
                CourseMeetingId = result.CourseMeetingId, 
                Title = result.Title,
                IsActive = result.IsActive.ToActiveStatus(),
                ExpiredDate = result.ExpiredDate.ToDateShortFormatString(),
                Description = result.Description,
            };
            return new SysResult<TeacherHomeworksViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult Update(TeacherHomeworksViewModel request, int currentUserId)
        {
            var model = new HomeworksModel()
            {
                Id = request.Id,
                Description = request.Description,
                Title = request.Title, 
                IsActive = request.IsActive.ToBoolean(),
                ExpiredDate = request.ExpiredDate.CharacterAnalysis().ToDate().ToUtcDateTime(),
                CourseMeetingId = request.CourseMeetingId,
                FilePath = request.FilePath
            };
            homeworksComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };

        }
        //===============================================================================
        public SysResult Delete(int courseMeetingBookletId, int teacherUserId)
        {
            homeworksComponent.Delete(courseMeetingBookletId, teacherUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            homeworksComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
