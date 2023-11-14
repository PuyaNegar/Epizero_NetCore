using Common.Objects;
using System;
using System.Collections.Generic;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.TrainingsServices
{
    public class WeekSchedulesService : IDisposable
    {
        private WeekSchedulesComponent weekSchedulesComponent;
        //=================================================
        public WeekSchedulesService()
        {
            weekSchedulesComponent = new WeekSchedulesComponent(); 
        } 
        //=================================================
        public SysResult<List<WeekSchedulesViewModel>> Read(int studentUserId)
        {
            var result = weekSchedulesComponent.Read(studentUserId);
            return new SysResult<List<WeekSchedulesViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            weekSchedulesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
