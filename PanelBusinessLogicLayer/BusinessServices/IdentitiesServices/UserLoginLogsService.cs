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
    public class UserLoginLogsService : IDisposable
    {
        private UserLoginLogsComponent userLoginLogsComponent;
        public UserLoginLogsService()
        {
            userLoginLogsComponent = new UserLoginLogsComponent();
        }
        //===================================================================
        public SysResult ReadLogHistories(int studentUserId)
        {
            var result = userLoginLogsComponent.ReadLogHistories(studentUserId);
 
            var viewModel = result.Select(c => new UserLoginHistoriesReadViewModel()
            {
               RegDateTime = c.RegDateTime.ToLocalDateTime().ToDateShortFormatString(),
               Count = c.CountLogin
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
 

        }

        //===================================================================
        public SysResult Read()
        {
            var result = userLoginLogsComponent.Read();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };

        }
        //===================================================================
        public SysResult Delete(int currentUserId , UserLoginHistoriesViewModel  viewModel)
        {
            userLoginLogsComponent.Delete(currentUserId ,viewModel.StudentUserId ,viewModel.LoginCount);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
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
