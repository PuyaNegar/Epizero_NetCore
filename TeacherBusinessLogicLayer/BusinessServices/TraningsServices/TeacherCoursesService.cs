using Common.Enums;
using Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using TeacherBusinessLogicLayer.BusinessComponents.TraningsComponents;
using TeacherViewModels.TraningsViewModels;

namespace TeacherBusinessLogicLayer.BusinessServices.TraningsServices
{
    public class TeacherCoursesService : IDisposable
    {
        private TeacherCoursesComponent coursesComponent;
        //=================================================
        public TeacherCoursesService()
        {
            coursesComponent = new TeacherCoursesComponent(); 
        } 
        //===============================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox(int teacherUserId )
        {
            var result = coursesComponent.Read(teacherUserId);
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message =SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        } 
        //===============================================================================
        public SysResult<List<TeacherCoursesViewModel>> ReadWithCourseMeetings(int teacherUserId , CourseCategoryType? courseCategoryType)
        {
            var result = coursesComponent.ReadWithCourseMeetings(teacherUserId , courseCategoryType); 
            return new SysResult<List<TeacherCoursesViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //============================================================================ Disposing
        #region DisposeObject
        public void Dispose()
        {
            coursesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
