﻿ using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters; 


namespace WebPresentationLayer.Infrastracture.Filters
{
    public class ApiService : ActionFilterAttribute
    {
        //======================================================================================================================
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Path.ToString().ToLower().StartsWith("/api"))
            {
                context.Result = new  NotFoundResult();
            }
        }
        //======================================================================================================================
    }
}
