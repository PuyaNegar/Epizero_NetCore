using Common.Extentions;
using Common.Objects;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using WebViewModels.IdentitiesViewModels;

namespace WebBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class UsersService : IDisposable
    {
        private UsersComponent usersComponent;
        //=================================================
        public UsersService()
        {
            usersComponent = new UsersComponent();
        }
        //=================================================
        public SysResult<LoginedUsersViewModel> Find(string UserName, string Password)
        {
            var result = usersComponent.Find(UserName.CharacterAnalysis().ToLower(), Password.CharacterAnalysis().HashMD5());
            return ConvertToDTOModel(result);
        }
        //=========================================================================
        public SysResult<LoginedUsersViewModel> Find(int UserId)
        {
            var result = usersComponent.Find(UserId);
            return ConvertToDTOModel(result);
        }
        public SysResult<int> GetCountStudent()
        {
            var result = usersComponent.GetCountStudent( );
            return new SysResult<int>() { IsSuccess = true, Message = "اطلاعات با موفقیت واکشی شد", Value = result };

        }
        //=========================================================================
        public SysResult ChangePassowrd(ChangePasswordViewModel viewModel, int CurrentUserId)
        {
            usersComponent.ChangePassword(CurrentUserId, viewModel.OldPassword.CharacterAnalysis(), viewModel.Password.CharacterAnalysis());
            return new SysResult() { IsSuccess = true, Message = "رمز عبور با موفقیت تغییر یافت" };
        }
        //=========================================================================
        SysResult<LoginedUsersViewModel> ConvertToDTOModel(UsersModel result)
        {
            var model = new LoginedUsersViewModel()
            {
                IsActive = result.IsActive,
                UserName = result.UserName,
                Id = result.Id,
                UserGroupId = result.UserGroupId,
                FirstName = result.FirstName,
                LastName = result.LastName
            };
            return new SysResult<LoginedUsersViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
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
            usersComponent?.Dispose();
        }
        #endregion
    }
}
