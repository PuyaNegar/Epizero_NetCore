using Common.Objects;
using System;
using System.Collections.Generic;
using TeacherBusinessLogicLayer.BusinessComponents.TraningsComponents;
using TeacherViewModels.TraningsViewModels;

namespace TeacherBusinessLogicLayer.BusinessServices.TraningsServices
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
        public SysResult<List<TeacherCourseMeetingVideoGroupsViewModel>> Read(int courseId , int teacherUserId)
        {  
            var result = courseVideosComponent.Read(courseId, teacherUserId); 
            return new SysResult<List<TeacherCourseMeetingVideoGroupsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
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
