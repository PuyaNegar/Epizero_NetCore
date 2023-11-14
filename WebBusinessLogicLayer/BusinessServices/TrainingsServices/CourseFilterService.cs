using Common.Enums;
using Common.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.TrainingsServices
{
   public class CourseFilterService : IDisposable
    {
        private CourseFilterComponent courseFilterComponent;

        public CourseFilterService()
        {
            courseFilterComponent = new CourseFilterComponent(); 
        }
        //=============================================================================== 
        public SysResult<List<FilterdCourseGroupsViewModel>>  Read(int levelGroupId)
        {
           var result =  courseFilterComponent.Read(levelGroupId);
           return new SysResult<List<FilterdCourseGroupsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result }; 
        }
        //=============================================================================== 
        public SysResult<List<FilterdCourseGroupsViewModel>> ReadByCourseTypeId(int courseTypeId)
        {
            var result = courseFilterComponent.ReadByCourseTypeId(courseTypeId);
            return new SysResult<List<FilterdCourseGroupsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseFilterComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
