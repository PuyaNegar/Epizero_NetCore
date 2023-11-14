using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.TeacherTrainingsComponents;
using PanelViewModels.TeacherTrainingsViewModels;
using System;
using System.Collections.Generic;

namespace PanelBusinessLogicLayer.BusinessServices.TeacherTrainingsServices
{
    public class TeacherCourseVideosService : IDisposable
    {
        private TeacherCourseVideosComponent courseVideosComponent;
        //===============================================================================
        public TeacherCourseVideosService()
        {
            courseVideosComponent = new TeacherCourseVideosComponent();
        }
        //===============================================================================
        public SysResult<List<TeacherCourseMeetingVideoGroupsViewModel>> Read(int courseId, int teacherUserId)
        {
            var result = courseVideosComponent.Read(courseId, teacherUserId);
            return new SysResult<List<TeacherCourseMeetingVideoGroupsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult<TeacherCourseMeetingVideosViewModel> Find(int id, int teacherUserId)
        {
            var result = courseVideosComponent.Find(id, teacherUserId);
            var model = new TeacherCourseMeetingVideosViewModel()
            {
                Id = result.Id,
                CourseMeetingName = result.CourseMeeting.Name,
                Title = result.Title,
                CourseMeetingId = result.CourseMeetingId,
                Description = result.Description,
                Link = result.Link,
                TeacherFullName = result.CourseMeeting.TeacherUser.FirstName + " " + result.CourseMeeting.TeacherUser.LastName,
                UserName = result.CourseMeeting.TeacherUser.UserName
            };
            return new SysResult<TeacherCourseMeetingVideosViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseVideosComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
