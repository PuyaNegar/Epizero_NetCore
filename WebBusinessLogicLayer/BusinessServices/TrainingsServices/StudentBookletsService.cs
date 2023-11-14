using Common.Objects;
using System;
using System.Collections.Generic;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.TrainingsServices
{
    public class StudentBookletsService : IDisposable
    {
        public SysResult<List<StudentCourseGroupsViewModel>> Read(int studentUserId)
        {
            var result = StudentCourseMeetingsComponent.ReadWithGrouping(studentUserId , Common.Enums.CourseCategoryType.Training);
            return new SysResult<List<StudentCourseGroupsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
