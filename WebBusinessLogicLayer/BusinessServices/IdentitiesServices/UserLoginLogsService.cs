using Common.Objects;
using DataModels.IdentitiesModels;
using System;
using System.Linq;
using WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using WebViewModels.IdentitiesViewModels;

namespace WebBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class UserLoginLogsService : IDisposable
    {
        private UserLoginLogsComponent userLoginLogsComponent;
        //===================================================================
        public UserLoginLogsService()
        {
            userLoginLogsComponent = new UserLoginLogsComponent();
        }
        //===================================================================
        public SysResult Add (UserLoginLogsViewModel viewModel , int studentUserId )
        {
            var model = new UserLoginLogsModel()
            {
                Guid = viewModel.Guid,
                LastIp = viewModel.Ip,
                LastLoginDateTime = DateTime.UtcNow,
                StudentUserId = studentUserId,
                LastUserAgent = viewModel.UserAgent, 
            };
            userLoginLogsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            userLoginLogsComponent?.Dispose();
        }
        #endregion
    }
}
