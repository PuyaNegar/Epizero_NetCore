using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.IdentitiesViewModels;

namespace WebPresentationLayer.Areas.Identities.Controllers
{
    [Area("Identities")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class AccountController : Controller
    {
        private UsersService usersService;
        //===========================================================================
        public AccountController()
        {
            usersService = new UsersService();
        }
        //===========================================================================
        [HttpPost]
        [UnAuthorize]
        [ApiService]
        public async Task<IActionResult> LoginWithUsername([FromBody] LoginViewModel login)
        {
            var result = usersService.Find(login.UserName.CharacterAnalysis().ToLower(), login.Password);

            if (result.Value.IsActive == false)
                return BadRequest(new SysResult() { IsSuccess = false, Message = "نام کاربری غیر فعال می باشد" });

            var UserClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , login.UserName) ,
                new Claim(ClaimTypes.Sid , result.Value.Id.ToString() ) ,
                new Claim(ClaimTypes.GroupSid ,  result.Value.UserGroupId.ToString()) ,
                new Claim(ClaimTypes.UserData , "") ,
            };
            var userIdentity = new ClaimsIdentity(UserClaim, "CookieBaseAuthentication");
            var prinical = new ClaimsPrincipal(userIdentity);
            var ExpireDate = DateTime.UtcNow.AddMonths(1);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, prinical, new AuthenticationProperties() { IsPersistent = true, ExpiresUtc = ExpireDate });
            AddLoginLogs(login.UniqueIdentifier, result.Value.Id);
            return Ok(new SysResult() { IsSuccess = true, Message = "شما با موفقیت به سیستم لاگین شدید" });
        }
        //===========================================================================
        [HttpPost]
        [UnAuthorize]
        [ApiService]
        public async Task<IActionResult> LoginWithMobNo([FromBody] ConfirmAndLoginViewModel request)
        {
            using (var confirmationCodes = new ConfirmationCodesService())
            {
                var result = confirmationCodes.Login(request);
                if (result.Value.IsActive == false)
                    return BadRequest(new SysResult() { IsSuccess = false, Message = "نام کاربری غیر فعال می باشد" });

                var UserClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , request.UserName) ,
                new Claim(ClaimTypes.Sid , result.Value.Id.ToString() ) ,
                new Claim(ClaimTypes.GroupSid ,  result.Value.UserGroupId.ToString()) ,
                new Claim(ClaimTypes.UserData , "") ,
            };
                var userIdentity = new ClaimsIdentity(UserClaim, "CookieBaseAuthentication");
                var prinical = new ClaimsPrincipal(userIdentity);
                var ExpireDate = DateTime.UtcNow.AddMonths(1);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, prinical, new AuthenticationProperties() { IsPersistent = true, ExpiresUtc = ExpireDate });

                AddLoginLogs(request.UniqueIdentifier, result.Value.Id);

                return Ok(new SysResult() { IsSuccess = true, Message = "شما با موفقیت به سیستم لاگین شدید" });
            }
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> JwtLogin([FromBody] LoginViewModel login)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var user = usersService.Find(login.UserName, login.Password);
                if (!user.IsSuccess)
                    return BadRequest(new SysResult() { IsSuccess = false, Message = "نام کاربری یا رمز عبور شما صحیح نمی باشد" });
                var result = user.Value;
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(AppConfigProvider.jwtTokenKey());
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                       new Claim(ClaimTypes.Name , login.UserName) ,
                       new Claim(ClaimTypes.Sid , result.Id.ToString() ) ,
                       new Claim(ClaimTypes.GroupSid ,  result.UserGroupId.ToString()) ,
                       new Claim(ClaimTypes.UserData , "") ,
                    }),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                result.Token = tokenHandler.WriteToken(token);
                return Ok(new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully, Value = result });
            });
        }
        //===========================================================================
        [HttpPost]
        [ApiService]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = usersService.ChangePassowrd(viewModel, GetCurrentUserId().Value);
                return Ok(result);
            });
        }
        //===========================================================================
        [Route("/SignOut")]
        public async Task<IActionResult> SignOut()
        {
            RemoveCartCookie();
            await HttpContext.SignOutAsync();
            return RedirectToAction("", "Home");
        }
        void AddLoginLogs(string UniqueIdentifier, int studentUserId)
        {
            using (var userLoginLogsService = new UserLoginLogsService())
            {
                try
                {
                    userLoginLogsService.Add(new UserLoginLogsViewModel()
                    {
                        Guid = UniqueIdentifier,
                        StudentUserId = studentUserId,
                        UserAgent = Request.Headers["User-Agent"],
                        Ip = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                    }, studentUserId);
                }
                catch
                {
                }

            }
        }
        //=============================================================================== 
        [ModelValidatorAsync]
        [Route("/LoginWithUrl")]
        public async Task<IActionResult>  LoginWithUrl([FromQuery] RefIntegerIdentifierViewModel login)
        {
            try
            {
                string data = login.RefId.DecriptWithDESAlgoritm();
                var userId = Convert.ToInt32(data.Split('#')[0]);
                var result = usersService.Find(userId).Value;
                var unixDateTime = Convert.ToInt64(data.Split('#')[1]);
                //if (unixDateTime.ConvertUnixToDateTime().AddMinutes(1) < DateTime.UtcNow)
                //    throw new Exception("توکن احراز هویت صحیح نمی باشد");
                if (!result.IsActive) 
                    return BadRequest(new SysResult() { IsSuccess = false, Message = "نام کاربری غیر فعال شده است" });
                //---------------------------------------------------------
                var UserClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , result.UserName) ,
                new Claim(ClaimTypes.Sid , result.Id.ToString() ) ,
                new Claim(ClaimTypes.GroupSid ,  result.UserGroupId.ToString()) ,
                new Claim(ClaimTypes.UserData , "") ,
            };
                var userIdentity = new ClaimsIdentity(UserClaim, "CookieBaseAuthentication");
                var prinical = new ClaimsPrincipal(userIdentity);
                var ExpireDate = DateTime.UtcNow.AddMonths(1);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, prinical, new AuthenticationProperties() { IsPersistent = true, ExpiresUtc = ExpireDate });

                AddLoginLogs(login.RefId, result.Id);
                return Redirect("/");
            }
            catch
            {
                return BadRequest(new SysResult() { IsSuccess = true, Message = "احراز هویت ناموفق" });
            }
        }
        //===========================================================================
        int? GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }

        //===========================================================================
        void RemoveCartCookie()
        {
            Response.Cookies.Delete("OrderHashId");
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            usersService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}