using Common.Extentions;
using Common.Objects;
using DataModels.IdentitiesModels;
using PanelViewModels.IdentitiesViewModels;
using System;
using TeacherBusinessLogicLayer.BusinessComponents.IdentitiesComponents;

namespace PanelBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class Teacher_UsersService : IDisposable
    {
        private Teacher_UsersComponent usersComponent;
        //=================================================
        public Teacher_UsersService()
        {
            usersComponent = new Teacher_UsersComponent();
        }
        //=================================================
        public SysResult<TeacherLoginedUsersViewModel> Find(string UserName, string Password)
        {
            var result = usersComponent.Find(UserName.CharacterAnalysis().ToLower(), Password.CharacterAnalysis().HashMD5());
            return ConvertToDTOModel(result);
        }
        //=========================================================================
        public SysResult<TeacherLoginedUsersViewModel> Find(int UserId)
        {
            var result = usersComponent.Find(UserId);
            return ConvertToDTOModel(result);
        }
        //=========================================================================
        public SysResult ChangePassowrd(TeacherChangePasswordViewModel viewModel, int CurrentUserId)
        {
            usersComponent.ChangePassword(CurrentUserId, viewModel.OldPassword.CharacterAnalysis(), viewModel.Password.CharacterAnalysis());
            return new SysResult() { IsSuccess = true, Message = "رمز عبور با موفقیت تغییر یافت" };
        }
        //=========================================================================
        SysResult<TeacherLoginedUsersViewModel> ConvertToDTOModel(UsersModel result)
        {
            var model = new TeacherLoginedUsersViewModel()
            {
                IsActive = result.IsActive,
                UserName = result.UserName,
                Id = result.Id,
                UserGroupId = result.UserGroupId,
                FirstName = result.FirstName,
                LastName = result.LastName
            };
            return new SysResult<TeacherLoginedUsersViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
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
