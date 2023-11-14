using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.TeacherTrainingsComponents;
using PanelViewModels.BaseViewModels;
using System;
using System.Collections.Generic;

namespace PanelBusinessLogicLayer.BusinessServices.TeacherTrainingsServices
{
    public class CourseStudentsReportsService : IDisposable
    {
        private CourseStudentsReportsComponent coursStudentsReportsComponent;
        //======================================================
        public CourseStudentsReportsService(int teacherUserId )
        {
            coursStudentsReportsComponent = new CourseStudentsReportsComponent(teacherUserId);
        }
        //======================================================
        public SysResult< List<IntegerKeyValueViewModel>> GetCities()
        {
           var result = coursStudentsReportsComponent.GetCities();
           return new SysResult<List<IntegerKeyValueViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result } ;
        }
        //======================================================== 
        public SysResult<List<IntegerKeyValueViewModel> >GetGenders()
        {
            var result = coursStudentsReportsComponent.GetGenders();
            return new SysResult<List<IntegerKeyValueViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result } ;
        }
        //=========================================================
        public SysResult<List<IntegerKeyValueViewModel>> GetLevels()
        {
            var result = coursStudentsReportsComponent.GetLevels();
            return new SysResult<List<IntegerKeyValueViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result } ;
        }
        //========================================================= 
        public SysResult<List<IntegerKeyValueViewModel>> GetFields()
        {
            var result = coursStudentsReportsComponent.GetFields();
            return new SysResult<List<IntegerKeyValueViewModel>>() { IsSuccess = true , Message = SystemCommonMessage.InformationFetchedSuccessfully , Value = result };
        } 
        //=========================================================
        public void Dispose()
        {
            coursStudentsReportsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        //=========================================================
    }
}
