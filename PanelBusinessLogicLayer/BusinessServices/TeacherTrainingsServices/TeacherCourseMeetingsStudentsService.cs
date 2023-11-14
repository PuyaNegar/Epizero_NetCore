using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.TeacherTrainingsComponents;
using PanelViewModels.TeacherTrainingsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.TeacherTrainingsServices
{
    public class TeacherCourseMeetingsStudentsService : IDisposable
    {
        private TeacherCourseMeetingsStudentsComponent courseMeetingsStudentsComponent;
        //==========================================
        public TeacherCourseMeetingsStudentsService()
        {
            courseMeetingsStudentsComponent = new TeacherCourseMeetingsStudentsComponent();
        }
        //==========================================
        public SysResult<List<TeacherCourseMeetingStudentsViewModel>> Read(int courseMeetingId, int teacherUserId)
        {
            var result = courseMeetingsStudentsComponent.ReadWithoutDuplicate(courseMeetingId, teacherUserId).Select(c => new TeacherCourseMeetingStudentsViewModel()
            {
                StudentFullName = c.StudentUsers.FirstName + " " + c.StudentUsers.LastName,
                StudentUserId = c.StudentUserId,
                CityName = c.StudentUsers.StudentUserProfile.City == null ?  "ثبت نشده" : c.StudentUsers.StudentUserProfile.City.Name,
                GenderName = c.StudentUsers.Gender ? "مرد" : "زن",
                CourseName = c.Course.Name, 
                CourseMeetingStudentType = c.CourseMeetingStudentType.Name,
            }).ToList();
            return new SysResult<List<TeacherCourseMeetingStudentsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //============================================================================ Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseMeetingsStudentsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
