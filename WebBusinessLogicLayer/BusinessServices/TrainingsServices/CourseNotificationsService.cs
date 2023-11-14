using Common.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.ContentsComponents;

namespace WebBusinessLogicLayer.BusinessServices.TrainingsServices
{
    public class CourseNotificationsService : IDisposable
    {
        private CourseNotificationsComponent courseNotificationsComponent;
        //======================================
        public CourseNotificationsService()
        {
            courseNotificationsComponent = new CourseNotificationsComponent();
        }
        //=====================================
        public SysResult Read(int studentUserId)
        {
            var result = courseNotificationsComponent.Read(studentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //======================================
        public void Dispose()
        {
            courseNotificationsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
