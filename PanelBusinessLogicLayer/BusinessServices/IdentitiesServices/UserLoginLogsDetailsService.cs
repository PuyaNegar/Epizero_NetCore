using Common.Extentions;
using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using PanelViewModels.IdentitiesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class UserLoginLogsDetailsService : IDisposable
    {
        private UserLoginLogsDetailsComponent userLoginLogsDetailsComponent;
        public UserLoginLogsDetailsService()
        {
            userLoginLogsDetailsComponent = new UserLoginLogsDetailsComponent();
        }
        //===================================================================
        public SysResult Read(int studentUserId)
        {
            var result = userLoginLogsDetailsComponent.Read(studentUserId);
            var viewModel = result.Select(c => new UserLoginLogsDetailsViewModel()
            {
                Id = c.Id,
                Guid = c.Guid,
                Ip = c.LastIp,
                RegDateTime = c.LastLoginDateTime.ToLocalDateTimeLongFormatString(),
                StudentUserFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                UserAgent = c.LastUserAgent,
                LoginCount=c.LoginCount.ToString()
            });
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
            userLoginLogsDetailsComponent?.Dispose();
        }
        #endregion
    }
}
