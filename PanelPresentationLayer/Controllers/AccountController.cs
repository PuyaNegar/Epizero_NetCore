using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using Common.Extentions;
using PanelViewModels.IdentitiesViewModels;
using Common.Enums;

namespace PanelPresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private AdminUsersService adminUsersService;
        private IWebHostEnvironment env;
        //=======================================================================================
        public AccountController(IWebHostEnvironment _env)
        {
            this.env = _env;
            this.adminUsersService = new AdminUsersService();
        }
        //=======================================================================================
        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            if (HttpContext.Session.GetString("Captcha") == null)
            {
                ViewBag.EnableCaptcha = false;
            }
            else
            {
                ViewBag.EnableCaptcha = true;
            }

            return View();
        }
        //=======================================================================================
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel login)
        {
            try
            {
                if (HttpContext.Session.GetString("Captcha") != null)
                {
                    TempData["EnableCaptcha"] = true;
                    if (HttpContext.Session.GetString("Captcha") != login.CaptchText.Trim().ToLower())
                    {
                        TempData["Message"] = "متن عکس صحیح نمی باشد";
                        return RedirectToAction("Index", "Account");
                    }
                }
                var result = adminUsersService.Find(login.Username.CharacterAnalysis().ToLower(), login.Password);
                if (!result.IsSuccess)
                {
                    TempData["Message"] = result.Message;
                    HttpContext.Session.SetString("Captcha", "true");
                    return RedirectToAction("Index", "Account");
                }
                if (result.Value.IsActive == ActiveStatus.Deactive)
                {
                    TempData["Message"] = "نام کاربری غیر فعال می باشد";
                    HttpContext.Session.SetString("Captcha", "true");
                    return RedirectToAction("Index", "Account");
                }
                //if (result.Value.IsConfirmed == ActiveStatus.Deactive)
                //{
                //    TempData["Message"] = "نام کاربری تایید نشده است";
                //    HttpContext.Session.SetString("Captcha", "true");
                //    return RedirectToAction("Index", "Account");
                //}
                var UserClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , login.Username) ,
                new Claim(ClaimTypes.Sid , result.Value.Id.ToString() ) ,
                new Claim(ClaimTypes.GroupSid ,  result.Value.UserGroupId.ToString()) ,
                new Claim(ClaimTypes.UserData , "") ,
            };
                var userIdentity = new ClaimsIdentity(UserClaim, "CookieBaseAuthentication");
                var prinical = new ClaimsPrincipal(userIdentity);
                var ExpireDate = (false) ? DateTime.UtcNow.AddMonths(1) : DateTime.UtcNow.AddHours(1);
                await HttpContext.SignInAsync("ASPNetCoreAuthenticationScheme", prinical, new AuthenticationProperties() { IsPersistent = false, ExpiresUtc = ExpireDate });
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                HttpContext.Session.SetString("Captcha", "true");
                return RedirectToAction("Index", "Account");
            }
        }
        //=======================================================================================
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Account");
        } 
        //=======================================================================================
        public IActionResult KeepAlive()
        {
            return Ok("");
        }

    }
}