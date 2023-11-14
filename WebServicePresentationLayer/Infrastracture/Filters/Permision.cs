using Common.Enums;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using WebBusinessLogicLayer.BusinessServices.SystemsServices;

namespace WebServicePresentationLayer.Infrastracture.Filters
{
    public class Permision : ActionFilterAttribute
    {
        private string UserGroups { get; set; }
        //===================================================================
        public Permision(string userGroups)
        {
            UserGroups = userGroups;
        }
        //===================================================================
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //try
            //{
            //    var userGroup = ((UserGroup)(Convert.ToInt32(context.HttpContext.User.Claims.ToList()[2].Value))).ToString();
            //    var result = UserGroups.Split(",").FirstOrDefault(c => c.Trim().ToLower() == userGroup.ToString().ToLower());
            //    if (result == null)
            //    {
            //        AddLogs(SystemCommonMessage.NoAccessToThisSection, context.HttpContext.Request.Path);
            //        throw new Exception(string.Empty);
            //    }

            //}
            //catch
            //{
            //    context.Result = new BadRequestObjectResult(new SysResult() { IsSuccess = false, Message = "شما مجوز دسترسی به این بخش را ندارید" });
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
