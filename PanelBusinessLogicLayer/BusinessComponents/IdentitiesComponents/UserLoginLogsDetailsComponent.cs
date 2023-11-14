using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class UserLoginLogsDetailsComponent : IDisposable
    {
        private Repository<UserLoginLogsModel> userLoginLogDetailsRepository;
        public UserLoginLogsDetailsComponent()
        {
            userLoginLogDetailsRepository = new Repository<UserLoginLogsModel>();
        }
        //=============================================================================== Disposing
        public IQueryable<UserLoginLogsModel> Read(int studentUserId)
        {
            var result = userLoginLogDetailsRepository.Where(x => x.StudentUserId == studentUserId, x=> x.StudentUser);
            return result;
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            userLoginLogDetailsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
