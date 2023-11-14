using Common.Enums;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
   public class SalesPartnerUsersComponent : IDisposable
    {
        private Repository<UsersModel> usersRepository;
        //===============================================================================
        public SalesPartnerUsersComponent()
        {
            usersRepository = new Repository<UsersModel>();
        }
        //===============================================================================
        public IQueryable<UsersModel> ReadForComboBox(UserGroup userGroup)
        {
            var result = usersRepository.Where(c => c.UserGroupId == (int)userGroup);
            return result;
        }
        //===============================================================================
        public IQueryable<UsersModel> Read()
        {
            var result = usersRepository.Where(c => c.UserGroupId == (int)UserGroup.SalesPartner, c => c.StudentUserProfile);
            return result;
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            usersRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
