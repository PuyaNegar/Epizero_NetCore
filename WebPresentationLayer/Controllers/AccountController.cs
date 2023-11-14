using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebPresentationLayer.Infrastracture.Filters;
using WebViewModels.IdentitiesViewModels;

namespace WebPresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        
        public IActionResult Login()
        {
            return View();
        }
 
    }
}
