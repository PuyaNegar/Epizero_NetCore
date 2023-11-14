﻿using Microsoft.AspNetCore.Mvc.Filters;
using WebBusinessLogicLayer.BusinessServices.SystemsServices;

namespace WebPresentationLayer.Infrastracture.Filters
{
    public class Permision : ActionFilterAttribute
    {
        //===================================================================
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //try
            //{
            //    var userGroup = (UserGroup)(Convert.ToInt32(context.HttpContext.User.Claims.ToList()[2].Value));
            //    if (userGroup != UserGroup.Admin && userGroup != UserGroup.SupperAdmin)
            //    {
            //        AddLogs(SystemCommonMessage.NoAccessToThisSection, context.HttpContext.Request.Path);
            //        throw new Exception(string.Empty);
            //    }
            //}
            //catch
            //{
            //    context.Result = new OkObjectResult(new SysResult() { IsSuccess = false, Message = "شما مجوز دسترسی به این بخش را ندارید" });
            //}

        }
        //===================================================================
        void AddLogs(string errorMessage, string errorSource)
        {
            using (var errorLogsService = new ErrorLogsService())
            {
                errorLogsService.Add(errorMessage, errorSource);
            }
        }
    }
}
