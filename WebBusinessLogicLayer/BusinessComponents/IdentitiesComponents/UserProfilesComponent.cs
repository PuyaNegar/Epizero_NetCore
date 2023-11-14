using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using System;
using WebBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using WebBusinessLogicLayer.UtilityComponent;

namespace WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class UserProfilesComponent : IDisposable
    {
        private Repository<StudentUserProfilesModel> userProfilesRepository;
        //=======================================================================
        public UserProfilesComponent()
        {
            userProfilesRepository = new Repository<StudentUserProfilesModel>();
        }
        //========================================================================
        public void AddOrUpdate(StudentUserProfilesModel model)
        {
            var result = userProfilesRepository.SingleOrDefault(c => c.UserId == model.UserId && c.User.UserGroupId == (int)UserGroup.Student, c => c.User);
            if (result == null)
            {
                Add(model);
            }
            else
                Update(result, model);
        }
        //public void UpdatePersonalImage(UserProfilesModel model)
        //{
        //    var result = userProfilesRepository.SingleOrDefault(c => c.UserId == model.UserId && c.User.UserGroupId == (int)UserGroup.GeneralUser, c => c.User);
        //    if (result == null)
        //        throw new CustomException(SystemCommonMessage.DataWasNotFound);
        //    result.User.PersonalPicPath = FileComponentProvider.Save(FileFolder.Student, model.User.PersonalPicPath);
        //    userProfilesRepository.Update(result);
        //    userProfilesRepository.SaveChanges();
        //}
        ////=====================================================
        //public void UploadRegisterFile(UserProfilesModel model)
        //{
        //    var result = userProfilesRepository.SingleOrDefault(c => c.UserId == model.UserId && c.User.UserGroupId == (int)UserGroup.GeneralUser, c => c.User);
        //    if (result == null)
        //        throw new CustomException(SystemCommonMessage.DataWasNotFound);
        //    if (result.User.IsConfirm.Value == true)
        //        throw new CustomException("امکان بارگزاری مجدد فرم ثبت نام وجود ندارد.");
        //    result.RegisterFormPath = FileComponentProvider.Save(FileFolder.UserRegisterForm, model.RegisterFormPath);
        //    result.RegisterFormUploadDateTime = model.RegisterFormUploadDateTime;
        //    userProfilesRepository.Update(result);
        //    userProfilesRepository.SaveChanges();
        //}
        //=====================================================
        public UsersModel Find(int UserId)
        {
            using (var usersRepository = new Repository<UsersModel>())
            {
                var result = usersRepository.SingleOrDefault(c => c.Id == UserId && c.UserGroupId == (int)UserGroup.Student, c => c.StudentUserProfile,c=> c.StudentUserProfile.City.Province);
                return result;
            }
        }
        //=====================================================
        void Add(StudentUserProfilesModel model)
        {
            using (var usersRepository = new Repository<UsersModel>())
            {
                var result = usersRepository.SingleOrDefault(c => c.Id == model.UserId && c.UserGroupId == (int)UserGroup.Student, c => c.StudentUserProfile);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                result.FirstName = model.User.FirstName;
                result.LastName = model.User.LastName;
                result.Gender = model.User.Gender;
                result.PersonalPicPath = FileComponentProvider.Save(FileFolder.Student, model.User.PersonalPicPath);
                result.StudentUserProfile = new StudentUserProfilesModel()
                {
                    BirthDay = model.BirthDay,
                    CityId = model.CityId,
                    FatherMobNo = model.FatherMobNo,
                    FieldId = model.FieldId,
                    LevelId = model.LevelId,
                    IntroductionWithAcademyTypeId = model.IntroductionWithAcademyTypeId,
                    NationalCardPicPath = FileComponentProvider.Save(FileFolder.Student, model.NationalCardPicPath),
                    MotherMobNo = model.MotherMobNo,
                    SchoolName = model.SchoolName,
                    SchoolTypeId = model.SchoolTypeId,
                    Email = model.Email,
                    UserId = model.UserId,
                };
                usersRepository.Update(result);
                usersRepository.SaveChanges();
            }
        }
        //=====================================================
        void Update(StudentUserProfilesModel data, StudentUserProfilesModel model)
        {
            data.User.PersonalPicPath = FileComponentProvider.Save(FileFolder.Student, model.User.PersonalPicPath);
            //data.User.FirstName = model.User.FirstName;
            //data.User.LastName = model.User.LastName;
            data.User.NationalCode = model.User.NationalCode;
            data.User.Gender = model.User.Gender;
            data.BirthDay = model.BirthDay;
            data.CityId = model.CityId;
            data.FavoriteJob = model.FavoriteJob;
            data.FatherMobNo = model.FatherMobNo;
            data.FieldId = model.FieldId;
            data.LevelId = model.LevelId;
            data.IntroductionWithAcademyTypeId = model.IntroductionWithAcademyTypeId;
            data.HomePhoneNumber = model.HomePhoneNumber;
            data.NationalCardPicPath = FileComponentProvider.Save(FileFolder.Student, model.NationalCardPicPath);
            data.MotherMobNo = model.MotherMobNo;
            data.SchoolName = model.SchoolName;
            data.SchoolTypeId = model.SchoolTypeId;
            data.Email = model.Email;
            data.UserId = model.UserId;
            userProfilesRepository.Update(data);
            userProfilesRepository.SaveChanges(); 
            new StudentUserScoresComponent().Reward(data.UserId, ScoringTariffs.CompleteProfile);
        }
        //=====================================================
        public void UpdateField(StudentUserProfilesModel model)
        {
            var data = userProfilesRepository.SingleOrDefault(c => c.UserId == model.UserId);
            if (data == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);

            data.FieldId = model.FieldId;
            
            userProfilesRepository.Update(data);
            userProfilesRepository.SaveChanges();
        }
        //======================================================== Disposing 
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
            userProfilesRepository?.Dispose();
        }
        #endregion

    }
}
