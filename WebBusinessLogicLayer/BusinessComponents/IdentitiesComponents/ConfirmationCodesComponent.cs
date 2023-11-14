using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Service;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using System;
using System.Linq;
using System.Threading;
using WebBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using WebBusinessLogicLayer.UtilityComponents.SmsComponents;
using WebViewModels.IdentitiesViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class ConfirmationCodesComponent : IDisposable
    {
        Repository<ConfirmationCodesModel> confirmationCodesRepository;
        Repository<UsersModel> usersRepository;
        //========================================================
        public ConfirmationCodesComponent()
        {
            confirmationCodesRepository = new Repository<ConfirmationCodesModel>();
            usersRepository = new Repository<UsersModel>();
        }
        //========================================================
        public ConfirmationCodesModel Add(string UserName, ConfirmationCodeType confirmationCodeType)
        {

            var result = usersRepository.SingleOrDefault(c => c.UserName.ToLower().Trim() == UserName.CharacterAnalysis().ToLower().Trim() && c.UserGroupId == (int)UserGroup.Student);
            if (confirmationCodeType == ConfirmationCodeType.Register)
            {
                if (result != null)
                    throw new CustomException("نام کاربری قبلا در بانک اطلاعاتی ثبت شده است");
            }
            else
            {
                if (result == null)
                    throw new CustomException("نام کاربری وارد شده در سیستم موجود نمی باشد");
            }
            var model = new ConfirmationCodesModel()
            {
                SentDateTime = DateTime.UtcNow,
                ExpireDateTime = DateTime.UtcNow.AddMinutes(2),
                UserName = UserName,
                SendCode = new Random().Next(10000, 99999).ToString(),
                IsConfirm = false,
            };
            confirmationCodesRepository.Add(model);
            confirmationCodesRepository.SaveChanges();
            SendSms(UserName, model.SendCode);
            return model;
        }


        //=============================================================================
        public ConfirmationCodesModel ReSendCode(string UserName, string HashId)
        {
            int Id = Convert.ToInt32(HashId.DecriptWithDESAlgoritm());
            var result = confirmationCodesRepository.SingleOrDefault(c => c.Id == Id && c.UserName == UserName && c.IsConfirm == false);
            if (result == null)
                throw new CustomException("شناسه ارسالی معتبر نمی باشد");
            if (result.ExpireDateTime.Subtract(DateTime.UtcNow).TotalSeconds > 0)
                throw new CustomException("زمان شما منقضی نشده است.");
            result.SendCode = new Random().Next(10000, 99999).ToString();
            result.ExpireDateTime = DateTime.UtcNow.AddMinutes(2);
            result.SentDateTime = DateTime.UtcNow;
            confirmationCodesRepository.Update(result);
            confirmationCodesRepository.SaveChanges();
            SendSms(UserName, result.SendCode);
            return result;
        }
        //========================================================
        public int ConfirmAndAddUser(RegisterViewModel viewModel)
        {
            var result = Confirm(viewModel.UserName.CharacterAnalysis(), viewModel.HashId, viewModel.ConfirmCode);
            if (usersRepository.Where(c => c.NationalCode == viewModel.NationalCode.CharacterAnalysis()).Any())
                throw new CustomException("کد ملی وارد شده قبلا در پایگاه داده ثبت شده است");

            result.IsConfirm = true;
            confirmationCodesRepository.Update(result);
            confirmationCodesRepository.SaveChanges();
            return AddUser(viewModel);
        }
        //========================================================
        ConfirmationCodesModel Confirm(string UserName, string HashId, string ConfirmCode)
        {
            if (string.IsNullOrEmpty(ConfirmCode))
                throw new CustomException("کد تایید نباید خالی باشد");
            int Id = Convert.ToInt32(HashId.DecriptWithDESAlgoritm());
            var result = confirmationCodesRepository.SingleOrDefault(c => c.Id == Id && c.UserName == UserName && c.IsConfirm == false);
            if (result == null)
                throw new CustomException("شناسه ارسالی معتبر نمی باشد");
            if (result.ExpireDateTime.Subtract(DateTime.UtcNow).TotalSeconds <= 0)
                throw new CustomException("زمان شما منقضی  شده است.");
            if (result.SendCode != ConfirmCode.CharacterAnalysis())
                throw new CustomException("کد وارد شده صحیح نمی باشد.");
            return result;
        }

        //========================================================
        //public bool IsValidConfirmCode(string UserName, string HashId)
        //{
        //    int Id = Convert.ToInt32(HashId.DecriptWithDESAlgoritm());
        //    var result = confirmationCodesRepository.SingleOrDefault(c => c.Id == Id && c.UserName == UserName && c.IsConfirm);
        //    if (result == null)
        //        return false;
        //    else
        //        return true;
        //}
        //========================================================
        int AddUser(RegisterViewModel viewModel)
        {
            using (var usersComponent = new UsersComponent())
            {
                var model = new UsersModel()
                {
                    UserName = viewModel.UserName.CharacterAnalysis(),
                    FirstName = viewModel.FirstName.CharacterAnalysis(),
                    LastName = viewModel.LastName.CharacterAnalysis(),
                    IsActive = true,
                    PasswoerdHash = viewModel.Password.CharacterAnalysis().HashMD5(),
                    UserGroupId = (int)UserGroup.Student,
                    Gender = viewModel.Gender.ToBoolean(),
                    NationalCode = viewModel.NationalCode.CharacterAnalysis(),
                    StudentUserProfile = new StudentUserProfilesModel()
                };
                var result = usersComponent.Add(model);
                IdentifierChargeOperation(viewModel, result);
                return result;
            }
        }
        //===========================================================================================
        public UsersModel ChangePassword(string UserName, string HashId, string Password)
        {
            int Id = Convert.ToInt32(HashId.DecriptWithDESAlgoritm());
            var result = confirmationCodesRepository.SingleOrDefault(c => c.Id == Id && c.UserName == UserName && c.IsConfirm);
            if (result == null)
                throw new CustomException("شناسه ارسالی معتبر نمی باشد");
            var user = usersRepository.SingleOrDefault(c => c.UserName == result.UserName && c.UserGroupId == (int)UserGroup.Student);
            user.PasswoerdHash = Password.CharacterAnalysis().HashMD5();
            usersRepository.Update(user);
            usersRepository.SaveChanges();
            return user;

        }
        //===========================================================================================
        public UsersModel ConfirmAndLogin(string UserName, string HashId, string ConfirmCode)
        {
            Confirm(UserName, HashId, ConfirmCode);
            var user = usersRepository.SingleOrDefault(c => c.UserName == UserName && c.UserGroupId == (int)UserGroup.Student);
            if (user == null)
                throw new CustomException("کاربر یافت نشد");
            return user;
        }
        //========================================================
        void IdentifierChargeOperation(RegisterViewModel viewModel, int result)
        {
            using (var identifierChargeComponent = new IdentifierChargeComponent())
            {
                identifierChargeComponent.Operation(viewModel.IdentifierUserHashId, result);
            }
        }
        //========================================================
        void SendSms(string username, string sendCode)
        {
            ConfirmationCodeSmsComponent.Operation(username, sendCode);
        }
        //======================================================== Disposing 
        #region DisposeObject
        public void Dispose()
        {
            confirmationCodesRepository?.Dispose();
            usersRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
