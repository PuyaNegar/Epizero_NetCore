using Common.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;

namespace WebBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class StudentAcademicProgressChartsService : IDisposable
    {
        StudentAcademicProgressChartsComponent academicProgressChartsComponent;
        //=====================================================================
        public StudentAcademicProgressChartsService()
        {
            academicProgressChartsComponent = new StudentAcademicProgressChartsComponent();
        }
        //=====================================================================
        public SysResult Read (int courseId  , int studentUserId)
        {
            var result = academicProgressChartsComponent.Read(courseId , studentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=====================================================================
        public void Dispose()
        {
            academicProgressChartsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        //=====================================================================
    }
}
