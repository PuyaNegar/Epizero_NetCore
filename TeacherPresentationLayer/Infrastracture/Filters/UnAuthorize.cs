using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TeacherPresentationLayer.Infrastracture.Filters
{
    public class UnAuthorize : ActionFilterAttribute
    {
        //======================================================================================================================
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new BadRequestObjectResult(new SysResult() { IsSuccess = false , Message = "شما در سیستم لاگین هستید و نیازی به احراز هویت مجدد ندارید" }  );
            }
        }
        //======================================================================================================================
    }
}
