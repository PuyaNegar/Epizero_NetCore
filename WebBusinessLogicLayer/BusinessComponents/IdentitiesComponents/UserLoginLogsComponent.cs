using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class UserLoginLogsComponent : IDisposable
    {
        private Repository<UserLoginLogsModel> userLoginLogsRepository;
        //======================================================
        public UserLoginLogsComponent()
        {
            userLoginLogsRepository = new Repository<UserLoginLogsModel>();
        }
        //======================================================
        public void Add(UserLoginLogsModel model)
        {
            var result = userLoginLogsRepository.SingleOrDefault(u => u.StudentUserId == model.StudentUserId &&
                                                                 u.Guid == model.Guid);
            if (result == null)
            {
                model.LoginCount = 1;
                userLoginLogsRepository.Add(model);
            }
            else
            {
                result.LastIp = model.LastIp;
                result.LastUserAgent = model.LastUserAgent;
                result.LastLoginDateTime = DateTime.UtcNow;
                result.LoginCount += 1;
                userLoginLogsRepository.Update(result);
            }
            userLoginLogsRepository.SaveChanges();

        }
        //======================================================5000248413
        public void Dispose()
        {
            userLoginLogsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
