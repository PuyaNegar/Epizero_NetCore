using Common.Objects;
using System;
using System.Collections.Generic;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.TrainingsServices
{
   public class CourseSearchService : IDisposable
    {
        private CourseSearchComponent courseSearchComponent; 
        //========================================
        public CourseSearchService()
        {
            courseSearchComponent = new CourseSearchComponent(); 
        }
        //===========================================
        public SysResult<List<CourseSearchResultViewModel>> Operation(string searchValue)
        {
           var result  =  courseSearchComponent.Operation(searchValue); 
            return new SysResult<List<CourseSearchResultViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        } 
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseSearchComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
