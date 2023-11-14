using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;
using Common.Extentions;
using Common.Objects;
using DataModels.IdentitiesModels;
using PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.IdentitiesViewModels;
using PanelViewModels.Identity;

namespace PanelBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class StudentUsersService : IDisposable
    {
        private StudentUsersComponent studentUsersComponent;
        //===============================================================================
        public StudentUsersService()
        {
            studentUsersComponent = new StudentUsersComponent();
        }

        //===============================================================================
        public SysResult Read()
        {
            var result = studentUsersComponent.Read().Select(c => new StudentUsersViewModel()
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.StudentUserProfile.Email,
                UserName = c.UserName,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
                NationalCode = c.NationalCode,
                FullName = c.FirstName + " " + c.LastName,
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult Add(StudentUsersViewModel request)
        {
            var model = new UsersModel()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender.ToBoolean(),
                UserName = request.UserName,
                NationalCode = request.NationalCode,
                IsActive = request.IsActive.ToBoolean(),
                PersonalPicPath = request.PersonalPicPath,
                PasswoerdHash = request.UserName.CharacterAnalysis().ToLower().HashMD5(),
                UserGroupId = (int)UserGroup.Student,
                StudentUserProfile = new StudentUserProfilesModel()
                {
                    BirthDay = string.IsNullOrEmpty(request.BirthDay) ? (DateTime?)null : request.BirthDay.ToDate().ToUtcDateTime(),
                    CityId = request.CityId,
                    Email = request.Email,
                    FatherMobNo = request.FatherMobNo,
                    MotherMobNo = request.MotherMobNo,
                    SchoolTypeId = request.SchoolTypeId,
                    SchoolName = request.SchoolName,
                    FieldId = request.FeildId,
                    LevelId = request.LevelId,
                    IntroductionWithAcademyTypeId = request.IntroductionWithAcademyTypeId, 
                    FavoriteJob = request.FavoriteJob,
                    NationalCardPicPath = request.NationalCardPicPath,
                    HomePhoneNumber = request.HomePhoneNumber
                }
            };
            studentUsersComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };

        }
        //===============================================================================
        public SysResult Update(StudentUsersViewModel request)
        {
            var model = new UsersModel()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender.ToBoolean(),
                IsActive = request.IsActive.ToBoolean(),
                PersonalPicPath = request.PersonalPicPath,
                NationalCode = request.NationalCode,
                UserName = request.UserName,
                StudentUserProfile = new StudentUserProfilesModel()
                {
                    BirthDay = string.IsNullOrEmpty(request.BirthDay) ? (DateTime?)null : request.BirthDay.ToDate().ToUtcDateTime(),
                    CityId = request.CityId,
                    Email = request.Email,
                    FatherMobNo = request.FatherMobNo,
                    MotherMobNo = request.MotherMobNo,
                    SchoolTypeId = request.SchoolTypeId,
                    SchoolName = request.SchoolName,
                    NationalCardPicPath = request.NationalCardPicPath, 
                    IntroductionWithAcademyTypeId = request.IntroductionWithAcademyTypeId,
                    FieldId = request.FeildId,
                    FavoriteJob = request.FavoriteJob,
                    HomePhoneNumber = request.HomePhoneNumber,
                    LevelId = request.LevelId
                }
            };
            studentUsersComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };

        }
        //===============================================================================
        public SysResult<StudentUsersViewModel> Find(int id)
        {
            var result = studentUsersComponent.Find(id);
            var model = new StudentUsersViewModel()
            {
                Id = result.Id,
                PersonalPicPath = result.PersonalPicPath,
                HomePhoneNumber = result.StudentUserProfile.HomePhoneNumber,
                FirstName = result.FirstName,
                LastName = result.LastName,
                UserName = result.UserName,
                Gender = result.IsActive.ToActiveStatus(),
                GenderName = result.IsActive ? "مرد" : "زن",
                IsActive = result.IsActive.ToActiveStatus(),
                IsActiveName = result.IsActive ? "فعال" : "غیر فعال",
                BirthDay = result.StudentUserProfile.BirthDay.HasValue ? result.StudentUserProfile.BirthDay.Value.ToLocalDateTime().ToDateShortFormatString() : null,
                Email = result.StudentUserProfile.Email,
                FatherMobNo = result.StudentUserProfile.FatherMobNo,
                MotherMobNo = result.StudentUserProfile.MotherMobNo,
                SchoolName = result.StudentUserProfile.SchoolName,
                NationalCode = result.NationalCode,
                SchoolTypeId = result.StudentUserProfile.SchoolTypeId,
                FeildId = result.StudentUserProfile.FieldId,
                LevelId = result.StudentUserProfile.LevelId,
                FavoriteJob = result.StudentUserProfile.FavoriteJob,
                IntroductionWithAcademyTypeId = result.StudentUserProfile.IntroductionWithAcademyTypeId,
                 
                NationalCardPicPath = result.StudentUserProfile.NationalCardPicPath,
                CityId = result.StudentUserProfile.CityId,
                CityName = result.StudentUserProfile.CityId == null ? string.Empty : result.StudentUserProfile.City.Province.Name + " _ " + result.StudentUserProfile.City.Name

            };
            return new SysResult<StudentUsersViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var UserIds = viewModel.Select(r => r.Id.Value).ToList();
            studentUsersComponent.Delete(UserIds);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //===============================================================================
        public SysResult ChangePassword(ChangePasswordViewModel viewModel)
        {
            studentUsersComponent.ChangePassword(viewModel.UserId, viewModel.Password);
            return new SysResult() { IsSuccess = true, Message = "عملیات تغییر رمز با موفقیت انجام شد" };
        }

        public SysResult GetActiveStatus(int Id)
        {

            var result = studentUsersComponent.Find(Id);
            var userStatusViewModel = new UserStatusViewModel()
            {
                IsActive = result.IsActive.ToActiveStatus(),
                UserId = result.Id,
                Username = result.UserName
            };
            return new SysResult() { IsSuccess = true, Message = "واکشی با موفقیت انجام شد", Value = userStatusViewModel };

        }
        //=================================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = studentUsersComponent.Read();
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Value = c.Id.ToString(),
                Text = c.FirstName + " " + c.LastName,
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===============================================================================
        public SysResult ChangeActiveStatus(UserStatusViewModel viewModel, int CurrentUserId)
        {
            //**********************************************  عملیات نگاشت
            var model = new UsersModel()
            {
                Id = viewModel.UserId,
                IsActive = viewModel.IsActive.ToBoolean(),
            };
            //**********************************************
            studentUsersComponent.ChangeActiveStatus(model, CurrentUserId);
            return new SysResult() { IsSuccess = true, Message = "عملیات با موفقیت انجام شد" };
        }
        //=========================================================================
        public SysResult<string> GetSiteLoginToken(int customerId)
        {
            var result = studentUsersComponent.GetSiteLoginToken(customerId);
            return new SysResult<string>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
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
            studentUsersComponent?.Dispose();
        }
        #endregion
    }
}
