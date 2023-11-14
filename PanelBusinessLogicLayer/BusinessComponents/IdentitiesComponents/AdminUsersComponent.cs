using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class AdminUsersComponent :  IDisposable
    {
        private Repository<UsersModel> usersRepository;
        //===============================================================================
        public AdminUsersComponent()
        {
            usersRepository = new Repository<UsersModel>(); 
        }
        //===============================================================================
        public   void Add(UsersModel model)
        {
            var result = usersRepository.SingleOrDefault(c => c.UserName.ToLower().Trim() == model.UserName.ToLower().Trim() && (c.UserGroupId == (int)UserGroup.Admin || c.UserGroupId == (int)UserGroup.SalesPartner || c.UserGroupId == (int)UserGroup.Supporter));
            if (result != null)
                throw new CustomException("نام کاربری قبلا در بانک اطلاعاتی ثبت شده است");
            usersRepository.Add(model);
            usersRepository.SaveChanges();
        }
        //===============================================================================
        public void ChangePassword(int CurrentUserId, string OldPassword, string NewPassword, bool AllowToChangeSupperAdminPassword)
        {
            var query = AllowToChangeSupperAdminPassword ?
                usersRepository.SingleOrDefault(c => c.Id == CurrentUserId && (c.UserGroupId == (int)UserGroup.Admin || c.UserGroupId == (int)UserGroup.SalesPartner || c.UserGroupId == (int)UserGroup.Supporter)) :
                usersRepository.SingleOrDefault(c => c.Id == CurrentUserId && (c.UserGroupId == (int)UserGroup.Admin || c.UserGroupId == (int)UserGroup.SalesPartner || c.UserGroupId == (int)UserGroup.Supporter));
            if (query == null) { throw new Exception("این کاربر در بانک اطلاعاتی یافت نشد"); }
            if (!string.IsNullOrEmpty(OldPassword))
                ComparePassword(query.PasswoerdHash, OldPassword);
            query.PasswoerdHash = NewPassword.HashMD5();
            usersRepository.Update(query);
            usersRepository.SaveChanges();
        }
        //================================================================================
        public void ChangePassword(int UserId, string password)
        {
            var query = usersRepository.SingleOrDefault(c => c.Id == UserId && (c.UserGroupId == (int)UserGroup.Admin || c.UserGroupId == (int)UserGroup.SalesPartner || c.UserGroupId == (int)UserGroup.Supporter));
            if (query == null) { throw new Exception("این کاربر در بانک اطلاعاتی یافت نشد"); }
            query.PasswoerdHash = password.HashMD5();
            usersRepository.Update(query);
            usersRepository.SaveChanges();
        }
        //===============================================================================
        public UsersModel Find(string Username, string Password)
        {
            Expression<Func<UsersModel, bool>> predicate = c => c.UserName == Username && c.PasswoerdHash == Password && (c.UserGroupId == (int)UserGroup.Admin || c.UserGroupId == (int)UserGroup.SalesPartner || c.UserGroupId == (int)UserGroup.Supporter);
            return FilterModel(predicate);
        }
        //===============================================================================
        public UsersModel Find(int UserId)
        {
            Expression<Func<UsersModel, bool>> predicate = c => c.Id == UserId && (c.UserGroupId == (int)UserGroup.Admin || c.UserGroupId == (int)UserGroup.SalesPartner || c.UserGroupId == (int)UserGroup.Supporter);
            return FilterModel(predicate);
        }
        //===============================================================================
        public IQueryable<UsersModel> Read(UserGroup userGroup)
        {
            var result = usersRepository.Where(c => c.UserGroupId == (int)userGroup , c=>c.UserGroup).Select(c => new UsersModel
            {
                Id = c.Id,
                UserName = c.UserName,
                IsActive = c.IsActive,
                FirstName = c.FirstName,
                LastName = c.LastName , 
                UserGroup = new UserGroupsModel() { Title = c.UserGroup.Title }, 
            });
            return result;
        }
        //===============================================================================
        public void Update(UsersModel model)
        {
            var user = usersRepository.SingleOrDefault(c => c.Id == model.Id && (c.UserGroupId == (int)UserGroup.Admin || c.UserGroupId == (int)UserGroup.SalesPartner || c.UserGroupId == (int)UserGroup.Supporter));
            if (user == null) { throw new Exception(SystemCommonMessage.DataWasNotFound); }
            user.IsActive = model.IsActive;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            usersRepository.Update(user);
            usersRepository.SaveChanges();
        }
        //===============================================================================
        void ComparePassword(string Password, string OldPassword)
        {
            if (OldPassword.HashMD5() != Password)
                throw new Exception("رمز قبلی صحیح نمی باشد");
        }
        //===============================================================================
        UsersModel FilterModel(Expression<Func<UsersModel, bool>> predicate)
        {
            var result = usersRepository.Where(predicate)
                .Select(c => new UsersModel()
                {
                    Id = c.Id,
                    IsActive = c.IsActive,
                    UserGroupId = c.UserGroupId,
                    UserName = c.UserName,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                }).FirstOrDefault();
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //===============================================================================
        public void Delete(List<int> UserIds)
        {
            usersRepository.Delete(c => UserIds.Contains(c.Id) && (c.UserGroupId == (int)UserGroup.Admin || c.UserGroupId == (int)UserGroup.SalesPartner || c.UserGroupId == (int)UserGroup.Supporter));
            usersRepository.SaveChanges();
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
