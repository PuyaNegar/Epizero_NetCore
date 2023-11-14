using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Common.Enums;
using Common.Objects;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.IdentitiesViewModels;

namespace WebPresentationLayer.Areas.Identities.Controllers
{
    [Area("Identities")]
    [UnAuthorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class ConfirmationCodesController : Controller
    {
        private ConfirmationCodesService confirmationCodesService;
        public ConfirmationCodesController()
        {
            confirmationCodesService = new ConfirmationCodesService();
        }
        //===========================================================================
        [ApiService]
        [HttpPost]
        public async Task<IActionResult> AddForRegister([FromBody] ConfirmMobNoViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = confirmationCodesService.Add(viewModel , ConfirmationCodeType.Register);
                return Ok(result);
            });
        }
        //============================================================================

        [ApiService]
        [HttpPost]
        public async Task<IActionResult> AddForLogin([FromBody] ConfirmMobNoViewModel viewModel )
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = confirmationCodesService.Add(viewModel , ConfirmationCodeType.Login);
                return Ok(result);
            });
        }
        //===========================================================================
        [ApiService]
        [HttpPost]
        public async Task<IActionResult> ReSendCode([FromBody] ConfirmationCodesViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = confirmationCodesService.ReSendCode(viewModel);
                return Ok(result);
            });
        }
        //===========================================================================
        //[ApiService]
        //[HttpPost]
        //public async Task<IActionResult> Confirm([FromBody] ConfirmationCodesViewModel viewModel)
        //{
        //    return await Task.Run<IActionResult>(() =>
        //    {
        //        var result = confirmationCodesService.Confirm(viewModel);
        //        return Ok(result);
        //    });
        //}
        //===========================================================================
        [ApiService]
        [HttpPost]
        public async Task<IActionResult> ConfirmAndAddUser([FromBody] RegisterViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = confirmationCodesService.ConfirmAndAddUser(viewModel);
                var UserClaim = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name , result.Value.UserName) ,
                    new Claim(ClaimTypes.Sid , result.Value.Id.ToString() ) ,
                    new Claim(ClaimTypes.GroupSid ,  result.Value.UserGroupId.ToString()) ,
                    new Claim(ClaimTypes.UserData , "") ,
                };
                var userIdentity = new ClaimsIdentity(UserClaim, "CookieBaseAuthentication");
                var prinical = new ClaimsPrincipal(userIdentity);
                var ExpireDate = DateTime.UtcNow.AddDays(1);
                HttpContext.SignInAsync("ASPNetCoreAuthenticationScheme", prinical, new AuthenticationProperties() { IsPersistent = false, ExpiresUtc = ExpireDate });
                return Ok(new SysResult()
                {
                    IsSuccess = true,
                    Message = result.Message,
                    Value = new ConfirmationCodesViewModel()
                    {
                        HashId = viewModel.HashId,
                        UserName = viewModel.UserName
                    }
                });
            });
        }
        //===========================================================================
        [ApiService]
        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] PasswordViewModel viewModel)
        {  
            return await Task.Run<IActionResult>(() =>
            {
              var result = confirmationCodesService.ChangePassword(viewModel); ;
                var UserClaim = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name , result.Value.UserName) ,
                    new Claim(ClaimTypes.Sid , result.Value.Id.ToString() ) ,
                    new Claim(ClaimTypes.GroupSid ,  result.Value.UserGroupId.ToString()) ,
                    new Claim(ClaimTypes.UserData , "") ,
                };
                var userIdentity = new ClaimsIdentity(UserClaim, "CookieBaseAuthentication");
                var prinical = new ClaimsPrincipal(userIdentity);
                var ExpireDate = DateTime.UtcNow.AddDays(1);
                HttpContext.SignInAsync("ASPNetCoreAuthenticationScheme", prinical, new AuthenticationProperties() { IsPersistent = false, ExpiresUtc = ExpireDate });
                return Ok(new SysResult()
                {
                    IsSuccess = true,
                    Message = result.Message,
                    Value = new ConfirmationCodesViewModel()
                    {
                        HashId = viewModel.HashId,
                        UserName = viewModel.UserName
                    }
                });
            });

        }
        //===========================================================================
        public int? GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            confirmationCodesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}