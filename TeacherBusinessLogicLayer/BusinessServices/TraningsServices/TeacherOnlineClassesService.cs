using Common.Functions;
using Common.Objects;
using System;
using System.Collections.Generic; 
using TeacherBusinessLogicLayer.BusinessComponents.TraningsComponents;
using TeacherViewModels.TraningsViewModels;

namespace TeacherBusinessLogicLayer.BusinessServices.TraningsServices
{ 
    public class TeacherOnlineClassesService : IDisposable
    {
        private TeacherOnlineClassesComponent onlineClassesComponent;
        //=================================================
        public TeacherOnlineClassesService()
        {
            onlineClassesComponent = new TeacherOnlineClassesComponent();
        }
        //=================================================
        public SysResult <List<TeacherOnlineClassesViewModel>> ReadActiveClass(int teacherUserId )
        {
            var result = onlineClassesComponent.ReadActiveClass(teacherUserId);
            return new SysResult<List<TeacherOnlineClassesViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        } 
        //=================================================
        public SysResult<List<TeacherOnlineClassesViewModel>> Read(int teacherUserId)
        {
            var result = onlineClassesComponent.Read(teacherUserId); 
            return new SysResult<List<TeacherOnlineClassesViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=================================================
        public SysResult Delete(int teacherUserId, int courseMeetingId)
        {
            onlineClassesComponent.Delete(teacherUserId , courseMeetingId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully };
        }
        //=================================================
        public SysResult<string> JoinToClass(int teacherUserId, int courseMeetingId)
        {
            var result = onlineClassesComponent.JoinToClass(teacherUserId , courseMeetingId);
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
