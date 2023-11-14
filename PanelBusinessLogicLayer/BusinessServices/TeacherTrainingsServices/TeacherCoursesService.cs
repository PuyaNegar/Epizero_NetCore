using Common.Enums;
using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.TeacherTrainingsComponents;
using PanelViewModels.TeacherTrainingsViewModels; 
using System;
using System.Collections.Generic;
using System.Linq; 
 
namespace PanelBusinessLogicLayer.BusinessServices.TeacherTrainingsServices
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
