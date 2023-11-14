using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic; 

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{ 
    public class OnlineClassesService : IDisposable
    {
        private OnlineClassesComponent onlineClassesComponent;
        //=================================================
        public OnlineClassesService()
        {
            onlineClassesComponent = new OnlineClassesComponent();
        }
        //=================================================
        public SysResult <List<OnlineClassesViewModel>> ReadActiveClass(    )
        {
            var result = onlineClassesComponent.ReadActiveClass();
            return new SysResult<List<OnlineClassesViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        } 
        //=================================================
        public SysResult<List<OnlineClassesViewModel>> Read(   )
        {
            var result = onlineClassesComponent.Read( ); 
            return new SysResult<List<OnlineClassesViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=================================================
        public SysResult Delete( int courseMeetingId)
        {
            onlineClassesComponent.Delete( courseMeetingId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully };
        }
        //=================================================
        public SysResult<string> JoinToClass( int courseMeetingId ,  int currentUserId )
        {
            var result = onlineClassesComponent.JoinToClass(courseMeetingId , currentUserId);
            return new SysResult<string>() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully, Value = result };
        }
        //===================================================  Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineClassesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    } 
}
