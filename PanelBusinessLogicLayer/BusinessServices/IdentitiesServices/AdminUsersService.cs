using System;
using Common.Enums;
using Common.Extentions;
using Common.Objects;
using DataModels.IdentitiesModels;
using PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using PanelViewModels.IdentitiesViewModels;
using System.Linq;
using System.Collections.Generic;
using PanelViewModels.BaseViewModels;

namespace PanelBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class AdminUsersService : IDisposable
    {
        private AdminUsersComponent adminUsersComponent { get; set; }
        //=========================================================================
        public AdminUsersService()
        {
            adminUsersComponent = new AdminUsersComponent();
        }
        //=========================================================================
        public SysResult Read( UserGroup userGroup )
        {
            var result = adminUsersComponent.Read(userGroup).Select(c => new AdminUsersViewModel()
            {
                Id = c.Id,
                UserName = c.UserName,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
                FirstName = c.FirstName,
                LastName = c.LastName , 
                UserGroupName = c.UserGroup.Title , 
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=========================================================================
        public SysResult Add(AdminUsersViewModel viewModel)
        {
            var model = new UsersModel()
            {
                IsActive = viewModel.IsActive.ToBoolean(),
                PasswoerdHash = viewModel.Password.HashMD5(),
                UserGroupId = (int)viewModel.UserGroupId , 
                UserName = viewModel.UserName,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Gender = viewModel.Gender.ToBoolean() ,   
                NationalCode =  viewModel.NationalCode , 
            };
            adminUsersComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded, Value = model };
        }
        //=========================================================================
        public SysResult<AdminUsersViewModel> Find(string UserName, string Password)
        {
            var result = adminUsersComponent.Find(UserName.CharacterAnalysis().ToLower(), Password.HashMD5());
            return ConvertToDTOModel(result);
        }
        //=========================================================================
        public SysResult<AdminUsersViewModel> Find(int UserId)
        {
            var result = adminUsersComponent.Find(UserId);
            return ConvertToDTOModel(result);
        }
        //=========================================================================
        public SysResult ChangePassword(CurrentUserChangePasswordViewModel viewModel, int CurrentUserId)
        {
            adminUsersComponent.ChangePassword(CurrentUserId, viewModel.OldPassword, viewModel.Password, true);
            return new SysResult() { IsSuccess = true, Message = "عملیات تغییر رمز با موفقیت انجام شد" };
        }
        //=========================================================================
        public SysResult ChangePassword(ChangePasswordViewModel viewModel)
        {
            adminUsersComponent.ChangePassword(viewModel.UserId, viewModel.Password);
            return new SysResult() { IsSuccess = true, Message = "عملیات تغییر رمز با موفقیت انجام شد" };
        }

        //========================================================================================
        public SysResult Update(EditAdminUsersViewModel viewModel)
        {
            var model = new UsersModel()
            {
                Id = viewModel.Id,
                IsActive = viewModel.IsActive.ToBoolean(),
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
            };
            adminUsersComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully };
        }

        public SysResult<List<ComboBoxItems>> ReadForComboBox(UserGroup userGroup)
        {
            var result = adminUsersComponent.Read(userGroup );
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Text = c.FirstName + " " + c.LastName,
                Value = c.Id.ToString()
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = "اطلاعات با موفقیت ثبت شد", Value = viewModel };
        }


        //=========================================================================
        SysResult<AdminUsersViewModel> ConvertToDTOModel(UsersModel result)
        {
            var model = new AdminUsersViewModel()
            {
                IsActive = result.IsActive.ToActiveStatus(),
                UserName = result.UserName,
                Id = result.Id,
                UserGroupId = result.UserGroupId,
                FirstName = result.FirstName,
                LastName = result.LastName , 
            };
            return new SysResult<AdminUsersViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var UserIds = viewModel.Select(r => r.Id.Value).ToList();
            adminUsersComponent.Delete(UserIds);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //============================================================================ Disposing
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
            adminUsersComponent?.Dispose();
        }
        #endregion
    }
}
