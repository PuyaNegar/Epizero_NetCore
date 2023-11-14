using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks; 
using Common.Functions;
using Common.Objects; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebServicePresentationLayer.Infrastracture.Filters;
using WebServicePresentationLayer.Infrastrcture.Filters;
using WebViewModels.IdentitiesViewModels;

namespace WebServicePresentationLayer.Areas.Identities.Controllers
{
    [Area("Identities")]
    [ApiVersion("1")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class AccountsController : ControllerBase
    {
        private UsersService usersService;
        //===========================================================================================
        public AccountsController()
        {
            usersService = new UsersService();
        }
        //===========================================================================================
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var user = usersService.Find(login.UserName, login.Password)  ;
                if(!user.IsSuccess)
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
        //================================================================================= Disposing
        #region DisposeObjects
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            usersService?.Dispose();
        }
        #endregion
    }
}