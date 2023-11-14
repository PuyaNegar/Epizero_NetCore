using Common.Objects;
using System;
using System.Collections.Generic;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.TrainingsServices
{
    public class OnlineClassesService : IDisposable
    {
        private OnlineClassesComponent onlineClassesComponent;
        //==============================================
        public OnlineClassesService()
        {
            onlineClassesComponent = new OnlineClassesComponent();
        }
        //==============================================
        public SysResult<List<OnlineClassesViewModel>> Read(int studentUserId)
        {
            var result = onlineClassesComponent.Read(studentUserId);
            return new SysResult<List<OnlineClassesViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully, Value = result };
        }
        //==============================================
        public SysResult<string> JoinToClass(int studentUserId, int courseId)
        {
            var result = onlineClassesComponent.JoinToClass(studentUserId, courseId); 
            return new SysResult<string>() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully, Value = result };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineClassesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
