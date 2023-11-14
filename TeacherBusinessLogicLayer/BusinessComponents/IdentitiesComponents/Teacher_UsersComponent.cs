using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace TeacherBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class Teacher_UsersComponent : IDisposable
    {
        private Repository<UsersModel> usersRepository;
        //===============================================================================
        public Teacher_UsersComponent()
        {
            usersRepository = new Repository<UsersModel>();
        }
        //===============================================================================
        public UsersModel Find(string Username, string Password)
        {
            Expression<Func<UsersModel, bool>> predicate = c => (c.UserName == Username) && c.PasswoerdHash == Password && c.UserGroupId == (int)UserGroup.Teacher;
            return FilterModel(predicate);
        }
        //===============================================================================
        public UsersModel Find(int UserId)
        {
            Expression<Func<UsersModel, bool>> predicate = c => c.Id == UserId && c.UserGroupId == (int)UserGroup.Teacher;
            return FilterModel(predicate);
        }
        //===============================================================================
        public void ChangePassword(int CurrentUserId, string OldPassword, string NewPassword)
        {
            var query = usersRepository.SingleOrDefault(c => c.Id == CurrentUserId && c.UserGroupId == (int)UserGroup.Teacher);
            if (query == null) { throw new Exception("این کاربر در بانک اطلاعاتی یافت نشد"); }
            if (!string.IsNullOrEmpty(OldPassword))
                ComparePassword(query.PasswoerdHash, OldPassword);
            query.PasswoerdHash = NewPassword.HashMD5();
            usersRepository.Update(query);
            usersRepository.SaveChanges();
        }
        //================================================================================
        UsersModel FilterModel(Expression<Func<UsersModel, bool>> predicate)
        {
            var result = usersRepository.Where(predicate, c => c.TeacherUserProfile)
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
        //===============================================================================
        public static UsersModel GetLastName(int teacherUserId)
        { 
            using (var repository = new Repository<UsersModel>())
            {
                var result = repository.Where(c => c.Id == teacherUserId, c => c.TeacherUserProfile).Select(c => new UsersModel()
                {
                    FirstName = c.FirstName, 
                    LastName = c.LastName,
                    TeacherUserProfile = new TeacherUserProfilesModel()
                    {
                         IsShowFinancial = c.TeacherUserProfile.IsShowFinancial,
                    }
                }).SingleOrDefault();
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result;
            }
        }
        //===============================================================================
        void ComparePassword(string Password, string OldPassword)
        {
            if (OldPassword.HashMD5() != Password)
                throw new Exception("رمز قبلی صحیح نمی باشد");
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
