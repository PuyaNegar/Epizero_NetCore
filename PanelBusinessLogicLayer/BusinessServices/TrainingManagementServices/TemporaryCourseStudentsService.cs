using Common.Enums;
using Common.Extentions;
using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class TemporaryCourseStudentsService : IDisposable
    {
        private TemporaryCourseStudentsComponent temporaryCourseStudentsComponent;
        //=======================================
        public TemporaryCourseStudentsService()
        {
            temporaryCourseStudentsComponent = new TemporaryCourseStudentsComponent();
        }
        //=======================================
        public SysResult Read(bool isActive)
        {
            var viewModel = temporaryCourseStudentsComponent.Read(isActive).Select(c => new TemporaryCourseStudentsViewModel()
            {
                Id = c.Id , 
                IsActiveName = c.Course.IsActive ? "فعال" : "غیرفعال",
                RegDateTime = c.RegDateTime.ToLocalDateTimeLongFormatString(),
                UserEditor = c.ModUser.FirstName + " " + c.ModUser.LastName,    
                StudentFullName = c.StudentUsers.FirstName + " " + c.StudentUsers.LastName,
                CourseMeetingStudentType = c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course ? "دوره " : "جلسه",
                CourseName = c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course ? "دوره " + c.Course.Name : c.CourseMeeting.Name + " ( دوره " + c.Course.Name + " ) " ,
                TeacherFullName = c.Course.TeacherUser.FirstName  + " " + c.Course.TeacherUser.LastName , 
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            temporaryCourseStudentsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
