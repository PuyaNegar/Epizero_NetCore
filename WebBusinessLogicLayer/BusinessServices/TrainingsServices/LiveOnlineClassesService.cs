using Common.Objects;
using System;
using System.Collections.Generic;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.TrainingsServices
{
    public class LiveOnlineClassesService : IDisposable
    {
        private LiveOnlineClassesComponent liveOnlineClassesComponent;
        //===============================================================================
        public LiveOnlineClassesService()
        {
            liveOnlineClassesComponent = new LiveOnlineClassesComponent();
        } 
        //==============================================
        public SysResult<List<OnlineClassesViewModel>> Read(int studentUserId)
        {
            var result = liveOnlineClassesComponent.Read(studentUserId);
            return new SysResult<List<OnlineClassesViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully, Value = result };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            liveOnlineClassesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
