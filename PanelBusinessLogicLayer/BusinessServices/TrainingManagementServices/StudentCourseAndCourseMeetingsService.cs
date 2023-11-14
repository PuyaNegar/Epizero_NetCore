using Common.Enums;
using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Linq;
using Common.Extentions;
namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class StudentCourseAndCourseMeetingsService : IDisposable
    {
        private StudentCourseAndCourseMeetingsComponent studentCourseAndCourseMeetingsComponent;
        //========================================================
        public StudentCourseAndCourseMeetingsService()
        {
            studentCourseAndCourseMeetingsComponent = new StudentCourseAndCourseMeetingsComponent();
        }
        //========================================================
        public SysResult Read(int studentUserId)
        {
            var result = studentCourseAndCourseMeetingsComponent.Read(studentUserId).Select(c => new StudentCourseAndCourseMeetingsViewModel()
            {
                CourseName = c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course ? c.Course.Name : c.CourseMeeting.Name + " ( " + c.Course.Name + " )",
                CourseMeetingStudentType = c.CourseMeetingStudentType.Name,
                RegDateTime = c.RegDateTime.ToLocalDateTime().ToDateShortFormatString(),
                IsTemporaryRegistrationName = c.IsTemporaryRegistration ? "موقت" : "قطعی" , 
                StudentFullName = c.StudentUsers.FirstName + " " + c.StudentUsers.LastName
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //========================================================
        public void Dispose()
        {
            studentCourseAndCourseMeetingsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
