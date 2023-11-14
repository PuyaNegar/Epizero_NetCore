using PanelBusinessLogicLayer.BusinessServices.SystemsServices;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Infrastracture.Filters
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
                if (context.HttpContext.Request.Path.ToString().EndsWith("/Delete/") || context.HttpContext.Request.Path.ToString().EndsWith("/Delete"))
                {
                    DefaultErrorMessage = "به دلیل وابستگی با سایر موجودیت ها امکان حذف وجود ندارد"; 
                }
                    if (context.Exception.GetType().Name == "CustomException")
                    {
                        context.Result = new OkObjectResult(new SysResult() { IsSuccess = false, Message = context.Exception.Message });
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(DefaultErrorMessage))
                        {
                            context.Result = new OkObjectResult(new SysResult() { IsSuccess = false, Message = DefaultErrorMessage });
                        }
                        else
                        {
                            context.Result = new OkObjectResult(new SysResult() { IsSuccess = false, Message = context.Exception.Message });
                        }
                    }
                return base.OnExceptionAsync(context);
            });
        }
        //=============================================================================
        void AddLogs(string errorMessage, string errorSource)
        {
            //using (var errorLogsService = new ErrorLogsService())
            //{
            //    errorLogsService.Add(errorMessage, errorSource);
            //}
        }
        //=============================================================================

    }
}
