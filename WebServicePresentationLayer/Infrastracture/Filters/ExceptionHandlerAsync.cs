using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.SystemsServices;

namespace WebServicePresentationLayer.Infrastracture.Filters
{
    public class ExceptionHandlerAsync : ExceptionFilterAttribute
    {
        public string DefaultErrorMessage { get; set; }
        //=============================================================================
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            await Task.Run(() =>
            {
                AddLogs(context.Exception.Message, context.HttpContext.Request.Path);
                if (context.Exception.GetType().Name == "CustomException")
                {
                    context.Result = new BadRequestObjectResult(new SysResult() { IsSuccess = false, Message = context.Exception.Message });
                }
                else
                {
                    if (!string.IsNullOrEmpty(DefaultErrorMessage))
                    {
                        context.Result = new BadRequestObjectResult(new SysResult() { IsSuccess = false, Message = DefaultErrorMessage });
                    }
                    else
                    {
                        context.Result = new BadRequestObjectResult(new SysResult() { IsSuccess = false, Message = context.Exception.Message });
                    }
                }
                return base.OnExceptionAsync(context);
            });
        }
        //=============================================================================
        void AddLogs(string errorMessage, string errorSource)
        {
            using (var errorLogsService = new ErrorLogsService())
            {
                errorLogsService.Add(errorMessage, errorSource);
            }
        }
        //=============================================================================

    }
}
