using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using PanelViewModels.IdentitiesViewModels;
using TeacherPresentationLayer.Infrastracture.Filters;
using TeacherPresentationLayer.Infrastracture.Functions;

namespace TeacherPresentationLayer.Areas.Identities.Controllers
{
    [Area("Identities")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class AccountController : Controller
    {
        private Teacher_UsersService usersService;
        //===========================================================================
        public AccountController()
        {
            usersService = new Teacher_UsersService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            });
        }
        //===========================================================================
        [HttpPost]
        [UnAuthorize]
        [ApiService]
        public async Task<IActionResult> LoginWithUsername([FromBody] TeacherLoginViewModel login)
        {
            var result = usersService.Find(login.UserName.CharacterAnalysis().ToLower(), login.Password);
           
            if (result.Value.IsActive == false) 
                return BadRequest(new SysResult() { IsSuccess = false , Message =  "نام کاربری غیر فعال می باشد"  });
             
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
            await HttpContext.SignInAsync("ASPNetCoreAuthenticationScheme", prinical, new AuthenticationProperties() { IsPersistent = true, ExpiresUtc = ExpireDate });
            return Ok(new SysResult() { IsSuccess = true, Message = "شما با موفقیت به سیستم لاگین شدید" });
        } 
        //===========================================================================
        [HttpPost]
        [ApiService]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] TeacherChangePasswordViewModel viewModel)
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
            await HttpContext.SignOutAsync();
            return RedirectToAction("", "Home");
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
            usersService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}