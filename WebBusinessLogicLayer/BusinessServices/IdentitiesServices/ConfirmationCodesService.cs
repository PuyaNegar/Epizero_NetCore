using Common.Enums;
using Common.Extentions;
using Common.Objects;
using DataModels.IdentitiesModels;
using System;
using WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using WebViewModels.IdentitiesViewModels;

namespace WebBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class ConfirmationCodesService : IDisposable
    {
        private ConfirmationCodesComponent confirmationCodesComponent;
        public ConfirmationCodesService()
        {
            confirmationCodesComponent = new ConfirmationCodesComponent();
        }
        //=========================================
        public SysResult<ConfirmationCodesViewModel> Add(ConfirmMobNoViewModel viewModel, ConfirmationCodeType confirmationCodeType)
        {
            var data = confirmationCodesComponent.Add(viewModel.UserName.CharacterAnalysis(), confirmationCodeType);
            var result = CreateConfirmationCodesViewModel(data);
            return new SysResult<ConfirmationCodesViewModel>() { IsSuccess = true, Message = "کد تایید به موبایل شما ارسال گردید", Value = result };
        }
        //=========================================
        public SysResult<ConfirmationCodesViewModel> ReSendCode(ConfirmationCodesViewModel viewModel)
        {
            var data = confirmationCodesComponent.ReSendCode(viewModel.UserName.CharacterAnalysis(), viewModel.HashId);
            var result = CreateConfirmationCodesViewModel(data);
            return new SysResult<ConfirmationCodesViewModel>() { IsSuccess = true, Message = "کد فعال سازی به موبایل شما ارسال گردید", Value = result };
        }
        //=========================================
        //public SysResult<ConfirmationCodesViewModel> Confirm(ConfirmationCodesViewModel viewModel)
        //{
        //    var data = confirmationCodesComponent.Confirm(viewModel.UserName.CharacterAnalysis(), viewModel.HashId, viewModel.ConfirmCode.CharacterAnalysis());
        //    var result = CreateConfirmationCodesViewModel(data);
        //    return new SysResult<ConfirmationCodesViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded, Value = result };
        //}
        //=========================================
        //public SysResult<bool> IsValidConfirmCode(ConfirmationCodesViewModel viewModel)
        //{
        //    var result = confirmationCodesComponent.IsValidConfirmCode(viewModel.UserName.CharacterAnalysis(), viewModel.HashId);
        //    return new SysResult<bool>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        //}
        //================================================
        public SysResult<LoginedUsersViewModel> ConfirmAndAddUser(RegisterViewModel viewModel)
        {
            var userId = confirmationCodesComponent.ConfirmAndAddUser(viewModel);
            var result = new LoginedUsersViewModel()
            {
                FirstName = viewModel.FirstName.CharacterAnalysis(),
                LastName = viewModel.LastName.CharacterAnalysis(),
                Id = userId,
                IsActive = true,
                UserName = viewModel.UserName.CharacterAnalysis(),
                UserGroupId = (int)UserGroup.Student,
            };
            return new SysResult<LoginedUsersViewModel>() { IsSuccess = true, Message = "ثبت نام شما با موفقیت انجام گردید", Value = result };
        }
        //==================================================
        public SysResult<LoginedUsersViewModel> ChangePassword(PasswordViewModel viewModel)
        {
            var result = confirmationCodesComponent.ChangePassword(viewModel.UserName.CharacterAnalysis(), viewModel.HashId, viewModel.Password);
            var model = new LoginedUsersViewModel()
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                Id = result.Id,
                IsActive = true,
                UserName = result.UserName,
                UserGroupId = (int)UserGroup.Student,
            };
            return new SysResult<LoginedUsersViewModel>() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully, Value = model };
        }
        //=========================================
        public SysResult<LoginedUsersViewModel> Login(ConfirmAndLoginViewModel request)
        {
            var result = confirmationCodesComponent.ConfirmAndLogin(request.UserName.CharacterAnalysis(), request.HashId, request.ConfirmCode);
            var model = new LoginedUsersViewModel()
            {
                Id = result.Id,
                UserGroupId = result.UserGroupId,
                FirstName = result.FirstName,
                UserName = result.UserName,
                IsActive = result.IsActive,
                LastName = result.LastName,
                NationalCode = result.NationalCode,
                Gender = result.Gender,
            };
            return new SysResult<LoginedUsersViewModel>() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully, Value = model };
        }
        //=========================================
        ConfirmationCodesViewModel CreateConfirmationCodesViewModel(ConfirmationCodesModel data)
        {
            var remainingTimeToExpire = Convert.ToInt32(data.ExpireDateTime.Subtract(DateTime.UtcNow).TotalSeconds);
            var result = new ConfirmationCodesViewModel()
            {
                HashId = data.Id.ToString().EncriptWithDESAlgoritm(),
                UserName = data.UserName,
                RemainingTimeToExpire = remainingTimeToExpire < 0 ? 0 : remainingTimeToExpire,
            };
            return result;
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
            confirmationCodesComponent?.Dispose();
        }
        #endregion


    }
}
