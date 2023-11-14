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

namespace PanelBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class TeacherUsersService : IDisposable
    {
        private TeacherUsersComponent teacherUsersComponent;
        //===============================================================================
        public TeacherUsersService()
        {
            teacherUsersComponent = new TeacherUsersComponent();
        }
        //===============================================================================
        public SysResult Add(TeacherUsersViewModel request)
        {
            var model = new UsersModel()
            {
                
                IsActive = request.IsActive.ToBoolean(),
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                NationalCode = request.NationalCode,
                Gender = request.Gender.ToBoolean(),
                PersonalPicPath = request.PersonalPicPath,
                UserGroupId = (int)UserGroup.Teacher,
                PasswoerdHash = request.UserName.CharacterAnalysis().ToLower().HashMD5(),
                TeacherUserProfile = new TeacherUserProfilesModel()
                {
                    BirthDay = string.IsNullOrEmpty(request.BirthDay) ? (DateTime?)null : request.BirthDay.ToDate().ToUtcDateTime(),
                    CityId = request.CityId,
                    Email = request.Email,
                    TeacherPrefixId = request.TeacherPrefixId,
                    Skill = request.Skill,
                    Description = request.Description,
                    BannerPicPath = request.BannerPicPath,
                    IsEnabledSms = request.IsEnabledSms.ToBoolean(),
                    IsShowFinancial = request.IsShowFinancial.ToBoolean(),
                    MetaDescription = request.MetaDescription,
                    TeacherUserTypeId = request.TeacherUserTypeId
                }
            };
            teacherUsersComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //===============================================================================
        public SysResult Read()
        {
            var result = teacherUsersComponent.Read().Select(c => new TeacherUsersViewModel()
            {
                Id = c.Id,
                FullName = c.FirstName + " " + c.LastName,
                FirstName = c.FirstName,
                TeacherUserTypeName = c.TeacherUserProfile.TeacherUserType.Name,
                LastName = c.LastName,
                UserName = c.UserName,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        public SysResult ReadById(int Id)
        {
            var result = teacherUsersComponent.Find(Id);
            var viewModel = new TeacherUsersViewModel()
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                UserName = result.UserName,
                IsActiveName = result.IsActive ? "فعال" : "غیر فعال",
            };
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===============================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox(UserGroup userGroup)
        {
            var result = teacherUsersComponent.Read(userGroup);
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Value = c.Id.ToString(),
                Text = c.FirstName + " " + c.LastName,
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===============================================================================
        public SysResult Update(TeacherUsersViewModel request)
        {
            var model = new UsersModel()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                PersonalPicPath = request.PersonalPicPath,
                LastName = request.LastName,
                Gender = request.Gender.ToBoolean(),
                IsActive = request.IsActive.ToBoolean(),
                UserName = request.UserName,
                TeacherUserProfile = new TeacherUserProfilesModel()
                {
                    BirthDay = string.IsNullOrEmpty(request.BirthDay) ? (DateTime?)null : request.BirthDay.ToDate().ToUtcDateTime(),
                    CityId = request.CityId,
                    Email = request.Email,
                    TeacherPrefixId = request.TeacherPrefixId,
                    Skill = request.Skill,
                    Description = request.Description,
                    BannerPicPath = request.BannerPicPath,
                    IsEnabledSms = request.IsEnabledSms.ToBoolean(),
                    IsShowFinancial = request.IsShowFinancial.ToBoolean(),
                    MetaDescription= request.MetaDescription,
                    TeacherUserTypeId = request.TeacherUserTypeId
                }
            };
            teacherUsersComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };

        }
        //===============================================================================
        public SysResult<TeacherUsersViewModel> Find(int id)
        {
            var result = teacherUsersComponent.Find(id);
            var model = new TeacherUsersViewModel()
            {
                Id = result.Id,
                FirstName = result.FirstName,
                PersonalPicPath = result.PersonalPicPath,
                LastName = result.LastName,
                UserName = result.UserName,
                NationalCode = result.NationalCode,
                Gender = result.Gender.ToActiveStatus(),
                GenderName = result.IsActive ? "مرد" : "زن",
                IsActive = result.IsActive.ToActiveStatus(),
                IsActiveName = result.IsActive ? "فعال" : "غیر فعال",
                BirthDay = result.TeacherUserProfile.BirthDay.HasValue ? result.TeacherUserProfile.BirthDay.Value.ToLocalDateTime().ToDateShortFormatString() : null,
                CityName = result.TeacherUserProfile.City.Province.Name + " _ " + result.TeacherUserProfile.City.Name,
                TeacherPrefixId = result.TeacherUserProfile.TeacherPrefixId,
                Skill = result.TeacherUserProfile.Skill,
                BannerPicPath = result.TeacherUserProfile.BannerPicPath,
                Description = result.TeacherUserProfile.Description,
                Email = result.TeacherUserProfile.Email,
                MetaDescription= result.TeacherUserProfile.MetaDescription,
                CityId = result.TeacherUserProfile.CityId,
                TeacherUserTypeId = result.TeacherUserProfile.TeacherUserTypeId,
                IsShowFinancial = result.TeacherUserProfile.IsShowFinancial.ToActiveStatus(),
                IsEnabledSms = result.TeacherUserProfile.IsEnabledSms.ToActiveStatus(),
            };
            return new SysResult<TeacherUsersViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var UserIds = viewModel.Select(r => r.Id.Value).ToList();
            teacherUsersComponent.Delete(UserIds);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //===============================================================================
        public SysResult ChangePassword(ChangePasswordViewModel viewModel)
        {
            teacherUsersComponent.ChangePassword(viewModel.UserId, viewModel.Password);
            return new SysResult() { IsSuccess = true, Message = "عملیات تغییر رمز با موفقیت انجام شد" };
        }
        //=================================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = teacherUsersComponent.Read();
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Value = c.Id.ToString(),
                Text = c.FirstName + " " + c.LastName,
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = "اطلاعات با موفقیت ثبت شد", Value = viewModel };
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
            teacherUsersComponent?.Dispose();
        }
        #endregion
    }
}
