using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPresentationLayer.Infrastracture.Filters
{
    public class AjaxAuthorize : ActionFilterAttribute
    {
        //======================================================================================================================
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            { 
                context.Result = new UnauthorizedObjectResult(new SysResult() { IsSuccess = false , Message = "شما بایستی لاگین شوید" });
            }
        }
        //======================================================================================================================
    }
}