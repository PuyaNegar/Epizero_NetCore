using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters; 

namespace TeacherPresentationLayer.Infrastracture.Filters
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