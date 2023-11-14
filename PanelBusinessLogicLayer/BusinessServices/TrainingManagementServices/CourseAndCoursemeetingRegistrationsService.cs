using Common.Extentions;
using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class CourseAndCoursemeetingRegistrationsService : IDisposable
    {
        private CourseAndCoursemeetingRegistrationsComponent courseAndCoursemeetingRegistrationsComponent;
        //===============================================================================
        public CourseAndCoursemeetingRegistrationsService()
        {
            courseAndCoursemeetingRegistrationsComponent = new CourseAndCoursemeetingRegistrationsComponent();
        }
        public SysResult Read()
        {
            var result = courseAndCoursemeetingRegistrationsComponent.Read()
                .Select(c => new CourseAndCoursemeetingRegistrationsViewModel()
                {
                    Id = c.Id,
                    IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
                    IsOnlineRegistrationName = c.IsOnlineRegistrated ? "آنلاین" : "دستی",
                    CourseMeetingName = c.CourseMeeting != null ?  c.CourseMeeting.Name : "ثبت نشده",
                    CourseName = c.Course.Name,
                    CourseMeetingStudentName = c.CourseMeetingStudentType.Name,
                    StudentFullName = c.StudentUsers.FirstName + " " + c.StudentUsers.LastName,
                    RegDateTime = c.RegDateTime.ToLocalDateTime().ToLocalDateTimeLongFormatString(),
                    CityName = c.StudentUsers.StudentUserProfile.City != null ?  c.StudentUsers.StudentUserProfile.City.Name : "ثبت نشده",

                });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };

        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseAndCoursemeetingRegistrationsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
