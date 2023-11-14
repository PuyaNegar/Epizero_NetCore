using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using PanelBusinessLogicLayer.UtilityComponent;

namespace PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class TeacherUsersComponent : IDisposable
    {
        private Repository<UsersModel> usersRepository;
        //===============================================================================
        public TeacherUsersComponent()
        {
            usersRepository = new Repository<UsersModel>();
        }
        //===============================================================================
        public void Add(UsersModel model)
        {
            var result = usersRepository.SingleOrDefault(c => (c.NationalCode == model.NationalCode || c.UserName == model.UserName) && c.UserGroupId == (int)UserGroup.Teacher);
            if (result != null)
                throw new CustomException("این کد ملی یا نام کاربری قبلا در سیستم ثبت نام کرده است");
            model.TeacherUserProfile.BannerPicPath = FileComponentProvider.Save(FileFolder.Teacher, model.TeacherUserProfile.BannerPicPath);
            model.PersonalPicPath = FileComponentProvider.Save(FileFolder.Teacher, model.PersonalPicPath);
            model.UserGroupId = (int)UserGroup.Teacher;
            model.PasswoerdHash = model.UserName.CharacterAnalysis().ToLower().HashMD5();
            usersRepository.Add(model);
            usersRepository.SaveChanges();
        }
        //===============================================================================
        public IQueryable<UsersModel> Read()
        {
            var result = usersRepository.Where(c => c.UserGroupId == (int)UserGroup.Teacher, c => c.TeacherUserProfile.TeacherUserType);
            return result;
        }
        //===============================================================================
        public IQueryable<UsersModel> Read(UserGroup userGroup)
        {
            var result = usersRepository.Where(c => c.UserGroupId == (int)userGroup, c => c.TeacherUserProfile);
            return result;
        }
        //===============================================================================
        public void Update(UsersModel model)
        {
            var query = usersRepository.SingleOrDefault(c => c.Id != model.Id && (c.NationalCode == model.NationalCode || c.UserName == model.UserName) && c.UserGroupId == (int)UserGroup.Teacher, c => c.StudentUserProfile);
            if (query != null)
                throw new CustomException("این کد ملی یا نام کاربری قبلا در سیستم ثبت نام کرده است");

            var result = usersRepository.SingleOrDefault(c => c.Id == model.Id && (c.UserGroupId == (int)UserGroup.Teacher), c => c.TeacherUserProfile);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.UserName = model.UserName;
            result.PersonalPicPath = FileComponentProvider.Save(FileFolder.Teacher, model.PersonalPicPath);
            result.FirstName = model.FirstName;
            result.LastName = model.LastName;
            result.Gender = model.Gender; 
            result.IsActive = model.IsActive;
            result.TeacherUserProfile.IsShowFinancial = model.TeacherUserProfile.IsShowFinancial;
            result.TeacherUserProfile.IsEnabledSms = model.TeacherUserProfile.IsEnabledSms; 
            result.TeacherUserProfile.Description = model.TeacherUserProfile.Description;
            result.TeacherUserProfile.BannerPicPath = FileComponentProvider.Save(FileFolder.Teacher, model.TeacherUserProfile.BannerPicPath);
            result.TeacherUserProfile.Skill = model.TeacherUserProfile.Skill;
            result.TeacherUserProfile.BirthDay = model.TeacherUserProfile.BirthDay;
            result.TeacherUserProfile.CityId = model.TeacherUserProfile.CityId;
            result.TeacherUserProfile.TeacherPrefixId = model.TeacherUserProfile.TeacherPrefixId;
            result.TeacherUserProfile.Email = model.TeacherUserProfile.Email;
            result.TeacherUserProfile.MetaDescription = model.TeacherUserProfile.MetaDescription;
            result.TeacherUserProfile.TeacherUserTypeId = model.TeacherUserProfile.TeacherUserTypeId;
            usersRepository.Update(result);
            usersRepository.SaveChanges();
        }
        //===============================================================================
        public UsersModel Find(int id)
        {
            var result = usersRepository.SingleOrDefault(c => c.Id == id && (c.UserGroupId == (int)UserGroup.Teacher), c => c.TeacherUserProfile.City.Province.Country);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //=============================================================================== 
        public void Delete(List<int> UserIds)
        { 
            using (var mainDBContext = new MainDBContext())
            {
                using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    { 
                        var UserProfilesRepository1 = new Repository<TeacherUserProfilesModel>(mainDBContext);
                        UserProfilesRepository1.Delete(c => UserIds.Contains(c.UserId) && c.User.UserGroupId == (int)UserGroup.Teacher);
                        UserProfilesRepository1.SaveChanges();

                        var UsersRepository1 = new Repository<UsersModel>(mainDBContext);
                        UsersRepository1.Delete(c => UserIds.Contains(c.Id) && c.UserGroupId == (int)UserGroup.Teacher);
                        UsersRepository1.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("اطلاعات به علت خطا ثبت نشد");
                    }
                }
            } 
        }
        //================================================================================
        public void ChangePassword(int UserId, string password)
        {
            var query = usersRepository.SingleOrDefault(c => c.Id == UserId && c.UserGroup.Id == (int)UserGroup.Teacher);
            if (query == null) { throw new Exception("این کاربر در بانک اطلاعاتی یافت نشد"); }
            query.PasswoerdHash = password.HashMD5();
            usersRepository.Update(query);
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
