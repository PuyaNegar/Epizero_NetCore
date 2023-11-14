using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using System;
using System.Linq;
using System.Linq.Expressions;
using WebBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using WebViewModels.IdentitiesViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class UsersComponent : IDisposable
    {
        private Repository<UsersModel> usersRepository;
        //===============================================================================
        public UsersComponent()
        {
            usersRepository = new Repository<UsersModel>();
        }
        //===============================================================================
        public int Add(UsersModel model)
        {
            var result = usersRepository.SingleOrDefault(c => c.UserName.ToLower().Trim() == model.UserName.ToLower().Trim() && c.UserGroupId == (int)UserGroup.Student);
            if (result != null)
                throw new CustomException("نام کاربری قبلا در بانک اطلاعاتی ثبت شده است");
            usersRepository.Add(model);
            usersRepository.SaveChanges();
            return model.Id;
        }
        //===============================================================================
        public void ChangePassword(int CurrentUserId, string OldPassword, string NewPassword)
        {
            var query = usersRepository.SingleOrDefault(c => c.Id == CurrentUserId && c.UserGroupId == (int)UserGroup.Student);
            if (query == null) { throw new Exception("این کاربر در بانک اطلاعاتی یافت نشد"); }
            if (!string.IsNullOrEmpty(OldPassword))
                ComparePassword(query.PasswoerdHash, OldPassword);
            query.PasswoerdHash = NewPassword.HashMD5();
            usersRepository.Update(query);
            usersRepository.SaveChanges();
        }
        //===============================================================================
        void ComparePassword(string Password, string OldPassword)
        {
            if (OldPassword.HashMD5() != Password)
                throw new Exception("رمز قبلی صحیح نمی باشد");
        }
        //===============================================================================
        public UsersModel Find(string Username, string Password)
        {
            Expression<Func<UsersModel, bool>> predicate = c => (c.UserName == Username) && c.PasswoerdHash == Password && c.UserGroupId == (int)UserGroup.Student;
            return FilterModel(predicate);
        }
        //===============================================================================
        public int GetCountStudent()
        {
            var result = usersRepository.Where(c => /*c.IsActive &&*/ c.UserGroupId == (int)UserGroup.Student);
            return result.Count();
        }
        //===============================================================================
        public UsersModel Find(int UserId)
        {
            Expression<Func<UsersModel, bool>> predicate = c => c.Id == UserId && c.UserGroupId == (int)UserGroup.Student;
            return FilterModel(predicate);
        }
        //===============================================================================
        UsersModel FilterModel(Expression<Func<UsersModel, bool>> predicate)
        {
            var result = usersRepository.Where(predicate, c => c.StudentUserProfile)
                .Select(c => new UsersModel()
                {
                    Id = c.Id,
                    IsActive = c.IsActive,
                    UserGroupId = c.UserGroupId,
                    UserName = c.UserName,
                    FirstName = c.FirstName,
                    LastName = c.LastName
                }).FirstOrDefault();
            if (result == null)
                throw new CustomException(SystemCommonMessage.LoginFaild);
            return result;
        }

        public static UserSummeryInfoViewModel GetName(int studentUserId)
        {
            var model = new UserSummeryInfoViewModel();
            using (var repository = new Repository<UsersModel>())
            {
                var result = repository.SingleOrDefault(c => c.Id == studentUserId);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                model.Name = result.FirstName;
            }
            using (var component = new StudentUserFinincesComponent())
            {
                model.Balance = component.GetBalance(studentUserId);
            }
            return model;
        }
        //=============================================================================== Disposing
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
            usersRepository?.Dispose();
        }
        #endregion



    }
}
