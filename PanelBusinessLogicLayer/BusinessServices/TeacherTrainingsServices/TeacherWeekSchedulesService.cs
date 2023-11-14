using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.TeacherTrainingsComponents;
using PanelViewModels.TeacherTrainingsViewModels;
using System;
using System.Collections.Generic; 

namespace PanelBusinessLogicLayer.BusinessServices.TeacherTrainingsServices
{
    public class TeacherWeekSchedulesService : IDisposable
    {
        private TeacherWeekSchedulesComponent teacherWeekSchedulesComponent;
        //=================================================
        public TeacherWeekSchedulesService()
        {
            teacherWeekSchedulesComponent = new  TeacherWeekSchedulesComponent(); 
        } 
        //=================================================
        public SysResult<List<TeacherWeekSchedulesViewModel>> Read(int studentUserId)
        {
            var result = teacherWeekSchedulesComponent.Read(studentUserId);
            return new SysResult<List<TeacherWeekSchedulesViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            teacherWeekSchedulesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
