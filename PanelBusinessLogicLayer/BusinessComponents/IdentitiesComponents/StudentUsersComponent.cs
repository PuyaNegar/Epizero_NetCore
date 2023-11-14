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
using Microsoft.EntityFrameworkCore;
using PanelBusinessLogicLayer.UtilityComponent;
using PanelBusinessLogicLayer.UtilityComponents.SmsComponents;

namespace PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class StudentUsersComponent : IDisposable
    {
        private Repository<UsersModel> usersRepository;
        //===============================================================================
        public StudentUsersComponent()
        {
            usersRepository = new Repository<UsersModel>();
        }
        //===============================================================================
        public IQueryable<UsersModel> Read()
        {
            var result = usersRepository.Where(c => c.UserGroupId == (int)UserGroup.Student, c => c.StudentUserProfile);
            return result;
        }
        //===============================================================================
        public void Add(UsersModel model)
        {
            if (!string.IsNullOrEmpty(model.NationalCode))
            {
                var nationalCodeIsExist = usersRepository.Where(c => c.NationalCode == model.NationalCode).Any();
                if (nationalCodeIsExist)
                    throw new CustomException("این کد ملی قبلا در سیستم ثبت شده است");
            }

            var result = usersRepository.FirstOrDefault(c => (c.UserName == model.UserName) && c.UserGroupId == (int)UserGroup.Student, c => c.StudentUserProfile);
            if (result != null)
                throw new CustomException("نام کاربری قبلا در سیستم ثبت نام کرده است");
            model.PersonalPicPath = FileComponentProvider.Save(FileFolder.Student, model.PersonalPicPath);
            usersRepository.Add(model);
            usersRepository.SaveChanges();
        }
        //===============================================================================
        public void Update(UsersModel model)
        {
            if (!string.IsNullOrEmpty(model.NationalCode))
            {
                var nationalCodeIsExist = usersRepository.Where(c => c.Id != model.Id && c.NationalCode == model.NationalCode).Any();
                if (nationalCodeIsExist)
                    throw new CustomException("این کد ملی قبلا در سیستم ثبت شده است");
            }
            var query = usersRepository.SingleOrDefault(c => c.Id != model.Id && (c.UserName == model.UserName) && c.UserGroupId == (int)UserGroup.Student, c => c.StudentUserProfile);
            if (query != null)
                throw new CustomException("این کد ملی یا نام کاربری قبلا در سیستم ثبت نام کرده است");
            var result = usersRepository.SingleOrDefault(c => c.Id == model.Id && c.UserGroupId == (int)UserGroup.Student, c => c.StudentUserProfile);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.PersonalPicPath = FileComponentProvider.Save(FileFolder.Student, model.PersonalPicPath);
            result.StudentUserProfile.NationalCardPicPath = FileComponentProvider.Save(FileFolder.Student, model.StudentUserProfile.NationalCardPicPath);
            result.FirstName = model.FirstName;
            result.UserName = model.UserName;
            result.LastName = model.LastName;
            result.NationalCode = model.NationalCode;
            result.Gender = model.Gender;
            result.IsActive = model.IsActive;
            result.StudentUserProfile.HomePhoneNumber = model.StudentUserProfile.HomePhoneNumber;
            result.StudentUserProfile.BirthDay = model.StudentUserProfile.BirthDay;
            result.StudentUserProfile.CityId = model.StudentUserProfile.CityId;
            result.StudentUserProfile.MotherMobNo = model.StudentUserProfile.MotherMobNo;
            result.StudentUserProfile.SchoolName = model.StudentUserProfile.SchoolName;
            result.StudentUserProfile.Email = model.StudentUserProfile.Email;
            result.StudentUserProfile.FavoriteJob = model.StudentUserProfile.FavoriteJob;
            result.StudentUserProfile.SchoolTypeId = model.StudentUserProfile.SchoolTypeId;
            result.StudentUserProfile.FatherMobNo = model.StudentUserProfile.FatherMobNo;
            result.StudentUserProfile.FieldId = model.StudentUserProfile.FieldId;
            result.StudentUserProfile.LevelId = model.StudentUserProfile.LevelId;
            result.StudentUserProfile.IntroductionWithAcademyTypeId = model.StudentUserProfile.IntroductionWithAcademyTypeId;
            usersRepository.Update(result);
            usersRepository.SaveChanges();
        }
        //===============================================================================
        public UsersModel Find(int id)
        {
            var result = usersRepository.SingleOrDefault(c => c.Id == id && c.UserGroupId == (int)UserGroup.Student, c => c.StudentUserProfile.City.Province.Country);
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
                        var UserProfilesRepository1 = new Repository<StudentUserProfilesModel>(mainDBContext);
                        UserProfilesRepository1.Delete(c => UserIds.Contains(c.UserId) && c.User.UserGroupId == (int)UserGroup.Student);
                        UserProfilesRepository1.SaveChanges();

                        var UsersRepository1 = new Repository<UsersModel>(mainDBContext);
                        UsersRepository1.Delete(c => UserIds.Contains(c.Id) && c.UserGroupId == (int)UserGroup.Student);
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
        //=============================================================================== 
        public void ChangePassword(int UserId, string password)
        {
            var query = usersRepository.SingleOrDefault(c => c.Id == UserId && c.UserGroup.Id == (int)UserGroup.Student);
            if (query == null) { throw new Exception("این کاربر در بانک اطلاعاتی یافت نشد"); }
            query.PasswoerdHash = password.HashMD5();
            usersRepository.Update(query);
            usersRepository.SaveChanges();
        }
        //=============================================================================== 
        public int GetCustomerId(string username)
        {
            using (var usersRepository = new Repository<UsersModel>())
            {
                var result = usersRepository.SingleOrDefault(c => c.UserName.Trim() == username && c.UserGroupId == (int)UserGroup.Student);
                if (result == null)
                    throw new Exception("دانش آموزی با این نام کاربری یافت نشد");
                return result.Id;
            }
        }
        //===============================================================================
        public void ChangeActiveStatus(UsersModel model, int CurrentUserId)
        {
            var user = usersRepository.SingleOrDefault(c => c.Id == model.Id && c.UserGroupId == (int)UserGroup.Student);
            if (user == null) { throw new Exception("این کاربر در بانک اطلاعاتی یافت نشد"); }
            user.IsActive = model.IsActive;
            usersRepository.Update(user);
            usersRepository.SaveChanges();
            if (!model.IsActive)
                DisableStudentSmsComponent.Operation(user.UserName, user.FirstName + " " + user.LastName);
        }
        //==============================================================================
        public string GetSiteLoginToken(int customerId)
        {
            var query = usersRepository.SingleOrDefault(c => c.Id == customerId);
            if (query == null)
                throw new Exception("مشتری یافت نشد");
            return AppConfigProvider.FrontEndUrl() + "/LoginWithUrl?RefId=" + (query.Id + "#" + DateTime.UtcNow.ToUnixDateTime()).EncriptWithDESAlgoritm();
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
