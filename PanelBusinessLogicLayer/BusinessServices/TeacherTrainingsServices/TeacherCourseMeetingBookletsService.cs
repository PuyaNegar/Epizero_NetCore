using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.BusinessComponents.TeacherTrainingsComponents;
using PanelViewModels.TeacherTrainingsViewModels;
using System;
using System.Linq; 

namespace PanelBusinessLogicLayer.BusinessServices.TeacherTrainingsServices
{
    public class TeacherCourseMeetingBookletsService : IDisposable
    {
        private TeacherCourseMeetingBookletsComponent courseMeetingBookletsComponent;
        //===============================================================================
        public TeacherCourseMeetingBookletsService()
        {
            courseMeetingBookletsComponent = new TeacherCourseMeetingBookletsComponent();
        }

        //===============================================================================
        public SysResult Read(int courseMeetingId, int teacherUserId)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var result = courseMeetingBookletsComponent.Read(courseMeetingId, teacherUserId).Select(c => new TeacherCourseMeetingBookletsViewModel()
            {
                Id = c.Id,
                IsActive = c.IsActive.ToActiveStatus(),
                FilePath = string.IsNullOrEmpty(c.FilePath) ? null : cdnUrl + c.FilePath,
                IsActiveName = c.IsActive ? "فعال" :"غیر فعال",
                CourseMeetingId = c.CourseMeetingId,
                Title = c.Title,
                CourseMeetingName = c.CourseMeeting.Name,
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult Add(TeacherCourseMeetingBookletsViewModel request, int currentUserId)
        {
            var model = new CourseMeetingBookletsModel()
            {
                FilePath = request.FilePath,
                Description = request.Description,
                Title = request.Title,
                CourseMeetingId = request.CourseMeetingId,
                IsActive = request.IsActive.ToBoolean(),
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId
            };
            courseMeetingBookletsComponent.Add(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }

        //===============================================================================
        public SysResult<TeacherCourseMeetingBookletsViewModel> Find(int id, int teacherUserId)
        {
            var result = courseMeetingBookletsComponent.Find(id, teacherUserId);
            var model = new TeacherCourseMeetingBookletsViewModel()
            {
                Id = result.Id,
                CourseMeetingName = result.CourseMeeting.Name,
                Title = result.Title,
                CourseMeetingId = result.CourseMeetingId,
                Description = result.Description,
                FilePath = result.FilePath,
                IsActive = result.IsActive.ToActiveStatus(),
            };
            return new SysResult<TeacherCourseMeetingBookletsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult Update(TeacherCourseMeetingBookletsViewModel request, int currentUserId)
        {
            var model = new CourseMeetingBookletsModel()
            {
                Id = request.Id, 
                Description = request.Description,
                Title = request.Title, 
                CourseMeetingId = request.CourseMeetingId,
                IsActive = request.IsActive.ToBoolean(),
            };
            courseMeetingBookletsComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };

        }
        //===============================================================================
        public SysResult Delete(int courseMeetingBookletId, int teacherUserId)
        {
            courseMeetingBookletsComponent.Delete(courseMeetingBookletId, teacherUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseMeetingBookletsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
