using Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using TeacherBusinessLogicLayer.BusinessComponents.TraningsComponents;

namespace TeacherBusinessLogicLayer.BusinessServices.TraningsServices
{
   public class TeacherCourseMeetingsService : IDisposable
    {
        private TeacherCourseMeetingsComponent courseMeetingsComponent;
        //===============================================================================
        public TeacherCourseMeetingsService()
        {
            courseMeetingsComponent = new TeacherCourseMeetingsComponent(); 
        } 
        //===============================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox(int courseId , int teacherUserId)
        {
            var result = courseMeetingsComponent.Read(courseId , teacherUserId);
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Text = c.Name, 
                Value = c.Id.ToString()
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //============================================================================ Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseMeetingsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
